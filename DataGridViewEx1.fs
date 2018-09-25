(*
    https://gist.github.com/joastbg/3946351
    Tables in F# forms
*)
open System
open System.Windows.Forms
open System.Drawing
// The form
let form = new Form(Visible = true, Text = "Data grid #1",
                    TopMost = true, Size = Drawing.Size(600,600))

// The grid
let data = new DataGridView(Dock = DockStyle.Fill, Text = "Data grid",
                            Font = new Drawing.Font("Lucida Console", 10.0f),
                            ForeColor = Drawing.Color.DarkBlue)
form.Controls.Add(data)

// Some data
data.DataSource <- [| ("ORCL", 32.2000, 31.1000, 31.1100, 0.0100);
                      ("MSFT", 72.050, 72.3100, 72.4000, 0.0900);
                      ("FB",162.9300,160.8800,165.7000,4.8200) |]

// Set column headers
do data.Columns.[0].HeaderText <- "Symb"
do data.Columns.[1].HeaderText <- "Last sale"
do data.Columns.[2].HeaderText <- "Bid"
do data.Columns.[3].HeaderText <- "Ask"
do data.Columns.[4].HeaderText <- "Spread"