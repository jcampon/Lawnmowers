# Lawn Mowers

A fleet of robotic lawn mowers are to be deployed to trim the grass of a large lawn.
This lawn, which is perfectly rectangular, must be navigated by the mowers so that they can maintain an even height of grass.  The lawn is bordered on all sides by gardens that contain rare plants.

A mower's position and location is represented by a combination of x and y co-ordinates and a letter representing one of the four cardinal compass points.  The lawn is divided up into a grid to simplify navigation. An example position might be 0, 0, N, which means the mower is in the bottom
left corner and facing North.

In order to control a mower, the remote controller sends a simple string of letters.  The possible letters are 'L', 'R' and 'M'. 'L' and 'R' makes the mower spin 90 degrees left or right respectively, without moving from its current spot.  'M' means move forward one grid point, and maintain the same heading.

Assume that the square directly North from (x, y) is (x, y+1).

####Requirements of the exercise

INPUT

The first line of input is the upper-right coordinates of the lawn, the lower-left coordinates are assumed to be 0,0.
 
The rest of the input is information pertaining to the mowers that have been deployed. Each mower has two lines of input. The first line gives the mower's position, and the second line is a series of instructions telling the mower how to explore the lawn.
 
The position is made up of two integers and a letter separated by spaces, corresponding to the x and y co-ordinates and the mower's orientation.
 
Each mower will be finished sequentially, which means that the second mower won't start to move until the first one has finished moving.

For this problem, we request that you use C# and write unit tests.  You may not use any external libraries to solve this problem, but you may use external libraries or tools for testing purposes.

OUTPUT

The output for each mower should be its final co-ordinates and heading.

####Input and Output examples:

Test Input:
5 5
1 2 N
LMLMLMLMM
3 3 E
MMRMMRMRRM

Expected Output:
1 3 N
5 1 E


####How to run it

* The implementation is an ASP.NET MVC5 website developed in Visual Studio 2015 Community Edition
* To run the site just download the solution in Visual Studio, build it and run it to use the application in a web browser
* The solution contains a set of unit tests implemented using NUnit


####What I am pleased with about my implementation

* First of all, the implementation does fullfil the criteria in terms of input and output values
* I think I've achieved a decent separation of concerns between the logic of the lawnmower operations - implemented on a service library - and the user interface. Another UI could be easily developed (maybe a console application for example) without having to touch pretty much anything from the service library.
* The unit tests added should cover the most relevant parts of the functionality.
* I implemented the principle of Dependency Inversion to allow Dependency Injection via the use of an IoC container with StructureMap
* Refactored parts of the code that could benefit from applying some design patterns, like substituting a bunch of IF blocks with an implementation of the Strategy pattern on the Validator class
* In terms of extensibility, it should be straigh forward to extend the code to make use of additional implementations of validators, parsers and service classes that would adhere to the specified interfaces
* The use of mocks for testing purposes would be very simple having coded the service clases against interfaces, which would then make mocking those clases a straightforward thing on the tests if necessary

####What I would do if I had more time

* The whole of the UI (a simple MVC site) is very basic and it is just enough to demostrate the service working functionality, but I added very little extra effort on the UI
* Validating parts of the input could have been done by using Regular Expressions instead of the alternative logic I implemented
* There is no logging functionality at all througout the solution, which in real projects should be a must
