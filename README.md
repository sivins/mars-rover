# Mars Rover

# Usage

See included Postman collection or SwaggerGen for usage examples.

## Design

I decided to go with a web service for my solution, since that's what I've been working with the most recently.  My solution follows the "Clean" or "Onion" architecture paradigm.  If the solution would have required more complexity, data persistence, or external service calls, I would have used multiple projects for the Application, Domain, Infrastructure, and External components respectively.

## Assumptions

* It was not stated in the specification, but I assumed that since the user can specify bounds, that an error should be encountered if the rover exceeds these bounds.
* Similarly, it is assumed that an error should be encountered if the rover travels into a negative X or Y position, as it would have fallen off the plateau.
* There was no mention of rovers not being able to move around eachother, so the MVP does not include logic to detect or avoid such collisions.