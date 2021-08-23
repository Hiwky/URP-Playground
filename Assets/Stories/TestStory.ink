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
Hey! You've visited this knot {counter} times.
-> hub
