///Compute the greatest common divisor of two numbers
let rec cmmdc x y =
    if y = 0 then
        x
    else
        cmmdc y (x % y)
       
let cmmdcc= cmmdc 1024 12