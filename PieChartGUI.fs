(*
    https://www.manning.com/books/real-world-functional-programming
    http://www.manning.com/Real-WorldFunctionalProgramming
    http://functional-programming.net
    http://code.msdn.microsoft.com/realworldfp
    https://docs.microsoft.com/en-us/dotnet/api/system.drawing.graphics.fillpie?view=netframework-4.7.2
*)

open System
open System.IO
open System.Drawing
open System.Windows.Forms

// Function to parse a line from a CSV file and convert it
// to (label,number) tuple
let convertLine (csvLine: string)=
    // Create an array of strings with individual data
    let stringArray=csvLine.Split([|','|])
    // Array should contain two elements
    match stringArray.Length=2 with
    | true -> let number=Int32.TryParse(stringArray.[1])
              if fst number then (stringArray.[0],(snd number))
              else failwith "Incorrect data format"
    | false -> failwith "Insufficient data on CSV line"

// Converts the data set loaded from CSV, from an array of strings
// to an array of (name, number) tuples
let processLines (lines: string array)=
    let tuplesArray= Array.map convertLine lines
    tuplesArray

// Calculate the sum of values from data set.
let calculateSum (lines: (string*int) [])=
    lines |> Array.sumBy (fun x -> (snd x))

//writePie "C:/Users/Nelu/Desktop/fsvsc/FSharp/population_2000.csv"

// Create main form window 
type PieChartGUI()=
    let form=new Form(Width=620, Height=450, Text="Pie Chart", BackColor=Color.Aquamarine)
    // Create the menu with two items
    let menu=new ToolStrip()
    let btnOpen=new ToolStripButton("Open")
    let btnSave=new ToolStripButton("Save")
    let _ =menu.Items.Add(btnOpen)
    let _ =menu.Items.Add(btnSave)
    do form.Controls.Add(menu)
    // Create picture box for displaying the chart
    let pictureBox=new PictureBox(BackColor=Color.White, Dock=DockStyle.Fill, SizeMode=PictureBoxSizeMode.CenterImage)
    do form.Controls.Add(pictureBox)

    member x.OpenFileDrawChartAndSave(e)=
        let drawPie (grp: Graphics) sum data =
            let rnd=Random()
            let rectangle=Rectangle(170, 70, 260, 260)
            let randomBrush()=
                let r, g, b=rnd.Next(256), rnd.Next(256), rnd.Next(256)
                new SolidBrush(Color.FromArgb(r, g, b))
            let drawStep data =
                let font=new Font("Times New Roman",11.0f)
                let centerX, centerY=300.0, 200.0
                let labelDistance=150.0
                let startAngle=ref 0.0f
                data |> Array.iter (fun x -> let brush=randomBrush()
                                             let sweepAngle=float32(snd x)/sum*360.0f
                                             grp.FillPie(brush,rectangle,!startAngle,sweepAngle)
                                             // Calculate angle where text should be (in radians)
                                             let rad=(Math.PI*2.0*float(!startAngle+sweepAngle/2.0f))/360.0
                                             // Calculate position for the center of the text
                                             let xStr=centerX+labelDistance*cos(rad)
                                             let yStr=centerY+labelDistance*sin(rad)
                                             // Get rectangle in which the text will be drawn
                                             let size=grp.MeasureString((fst x), font)
                                             let rectCoord=PointF(float32(xStr)-size.Width/2.0f, float32(yStr)-size.Height/2.0f)
                                             let rect=RectangleF(rectCoord, size)
                                             grp.DrawString((fst x), font, Brushes.Black, rect)
                                             startAngle:=!startAngle+sweepAngle
                                   ) 
            drawStep data

        let drawChart file=
            // Load file, convert it to array of tuples and calculate
            let lines=Array.ofSeq(File.ReadAllLines(file))
            let data=processLines(lines)
            let sum=float32(calculateSum(data))
            printfn "%f" sum
            // Create a bitmap object for drawing on it
            let bitmap=new Bitmap(600,400)
            let graphics=Graphics.FromImage(bitmap)
            // Fill with white Color
            graphics.Clear(Color.White)
            // Draw the chart
            drawPie graphics sum data
            graphics.Dispose() |> ignore
            bitmap

        let openFileAndDrawChart (e)=
            let dialog=new OpenFileDialog(Filter="CSV Files|*.csv")
            if dialog.ShowDialog()=DialogResult.OK 
            then let pieChart=drawChart dialog.FileName
                 pictureBox.Image <- pieChart
            else failwithf "Can't open input file! "
                
        btnOpen.Click.Add(openFileAndDrawChart)

        let saveDrawing (e)=
            let dialog=new SaveFileDialog(Filter="PNG Files|*png")
            if dialog.ShowDialog()=DialogResult.OK 
            then pictureBox.Image.Save(dialog.FileName)
            else failwith "Can't create output image"

        btnSave.Click.Add(saveDrawing)
        
    member x.Show()=
        form.ShowDialog()

let pieChart=PieChartGUI()
pieChart.OpenFileDrawChartAndSave()
pieChart.Show() |> ignore