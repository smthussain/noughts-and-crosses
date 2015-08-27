# Noughts and Crosses

A simple console app that shows a computer playing itself. There is no strategy - positions are picked at random.

Feature Specification
---------------------
* playa game of tic-tac-toe between two computer players
* display the game board at the start of the game and ensure it is updated after everymove
* prompt the user to begin the game
* make random moves by each player
* pause for one second before updating the game board between moves
* offer to run another game at the end of a game
* display the result of the game at the end of the game

Design Consideration
--------------------
* SOLID principles - used throughout, and documented through the code. 
* KISS / YAGNI - just as under-engineered speghetti code is an issue, so is over-engineered code with too many abstractions. This game has very simple dynamics, so in some cases I've gone for a simple solution
* Design patterns - I didn't see the need for any for such a simple solution (Game or Board Factory? Nah, overkill). Now if we had a game with multiple rules, that would be another matter

Architecture
------------
* Target framework is .NET 4.5. Solution was developed in VS2012 + Resharper
* We have a UI, that has an outer loop (to replay games) and an inner loop (taking turns within a game)
* All the complex logic has been pushed into a logic assembly
* The only entry point to this logic is the public IBoard. The is implemented by Board, which in turn farms out various bits of logic to other components
* All dependancies to the logic are via contracts (DIP), and are resolved with an IoC container (Autofac)

Testing
-------
* Tests come in their own assembly. They are all unit (not integration) tests, using MSTest, Moq and Autofac.
* All logic components have their own set of tests (expect IBoardCells, which is just simple encapsulation of a basic collecion of enums) - hopefully the long test names are self-explanatory
* There is no UI testing - the UI logic is reduced to just loops, informational messages and pauses - nothing easily testable there


