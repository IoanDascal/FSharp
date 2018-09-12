///We can combine funtions for lists
let firstHundred=[10..110]
let filtrat=List.map (fun x->2*x+5) (List.filter (fun x->x%2=0) firstHundred)