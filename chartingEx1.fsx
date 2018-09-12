#load "../packages/packages/FSharp.Charting.0.90.14/FSharp.Charting.fsx"
open FSharp.Charting

let rnd=System.Random()
let rand()=rnd.NextDouble()
let randomPoints=[for i in 0..100 -> -10.0*rand(),10.0*rand()]
let randomTrend1=[for i in -10.0..0.1..10.0 -> i,sin i + rand()]
let randomTrend2=[for i in -10.0..0.1..10.0 -> i,cos i + rand()]
let points=[(0.0,0.0);(10.0,10.0);(-10.0,2.0)]
Chart.Combine [Chart.Line randomTrend1;Chart.Line randomTrend2;Chart.Point randomPoints;Chart.Line points]