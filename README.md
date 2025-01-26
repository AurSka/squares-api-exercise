# Squares API
## Problem Definition
### The bigger picture
The Squares solution is designed to enable our enterprise consumers to identify squares from coordinates and thus make the world a better place.

A user interface allows a user to import a list of points, add and delete a point to an existing list. On top of that the user interface displays a list of squares that our amazing solution identified.

### The task
The Squares UI team is taking care of the front-end side of things, however they need your help for the backend solution.

Create an API that from a given set of points in a 2D plane - enables the consumer to find out sets of points that make squares and how many squares can be drawn. A point is a pair of integer X and Y coordinates. A square is a set of 4 points that when connected make up, well, a square. 

### Example of a list of points that make up a square:
```[(-1;1), (1;1), (1;-1), (-1;-1)]```

### API request/response contracts
Up to you! Design API contracts how you desire - as long as the UI team can use the API to solve user's problems.

## Requirements
### Functional
* I as a user can import a list of points
* I as a user can add a point to an existing list
* I as a user can delete a point from an existing list
* I as a user can retrieve the squares identified

### Non-fuctional
* Include prerequisites and steps to launch in `README`
* The solution code must be in a `git` repository
* The API should be implemented using .NET Core framework (ideally the newest stable version)
* The API must have some sort of persistance layer
* After sending a request the consumer shouldn't wait more than 5 seconds for a response

### Bonus points stuff!
* RESTful API
* Documentation generated from code (hint - `Swagger`)
* Automated tests
* Containerization/deployment (hint - `Docker`)
* Performance considerations
* Measuring SLI's
* Considerations for scalability of the API
* Comments/thoughts on the decisions you made

### A quick tip:
Don't reinvent the wheel when it comes to identifying squares. There are plenty of existing solutions to the problem online!

## The time for the solution
Take *as long as you need* on the solution but we suggest to limit yourself at 8 hours. Do let us know how much time it took you!

The task is not made to be completed in the period of 8 hours and no one expects you to! However, knowing how much time you spent and seeing the solution you came up with allows for seeing what you prioritize and where you would consider cutting corners on a sharp deadline.

# The Result

Time taken to write this: 7-8 hours

To use this:
1. Write in the connection string for the database in the Context file. 
2. Create the database and schema with the migrations, by running `dotnet ef database update`
3. Deploy using IIS Express. You could use Docker as well, but make sure the container can reach the database.

Now the methods. They are defined via Swagger as well, but I'll define them here as well:
- [HttpPost] Add (int x, int y) - Adds a point in the defined coordinates, if one isn't there already.
- [HttpDelete] Delete (int x, int y) - Deletes a point in the defined coordinates, if one is present.
- [HttpPost] Import (int[] x, int[] y, bool overwrite = true) - Imports an array of points by the X and Y coordinates indicated. If overwrite is true, overwrites the existing points.
- [HttpGet] Get () - Gets a list of four-point lists, each of which makes up a square.
