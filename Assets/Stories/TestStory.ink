EXTERNAL LogLine(text)
EXTERNAL Camera(cameraName)
-> first_time

===first_time===
{not first_knot: Hi, I'm Knotty. }
->first_knot

===first_knot===
This is the first knot.
+ [Show me more]
    -> hub
+ [I've seen enough]
Ok then, bye!
    -> DONE

===second_knot===
This is the second knot.
I'm logging a line now! 
~ LogLine("Logging from Ink!")
    -> hub

===hub===
Welcome to the hub.
Where would you like to go?
* [First knot]
    -> first_knot
* [Second knot]
    -> second_knot
+ [Counter knot]
    -> counter
+ [Bye]
    Goodbye! ->DONE

===counter===
~ Camera("face")
Hey! You've visited this knot {counter} times.
-> hub

===default_knot===
You're not supposed to see this!
-> DONE