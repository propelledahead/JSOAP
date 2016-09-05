# JSOAP
JSON based web service architecture example to illustrate standards definitions.

## Summary
In general you have the following:
- JSON Web Services Description Language (JWSDL) for JSOAP
- JSON Web Service Envelopes (JWSE) for JSOAP

## Attribution
Author: David P Smith
License: Creative Commons Attribution 4.0 International
Site: http://PropelledAhead.com/
Blog http://techartisans.blogspot.com/
Fiddles: https://jsfiddle.net/user/techartisans/fiddles/

## JSON Web Services Description Language (JWSDL) for JSOAP

For those in web development or enterprise development we have seen a number of wonderful innovations come out over the past few years. Namely JSON, SOAP, and RESTful web services among other great things such as great API's like jQuery.

This post is an attempt to develop a JSON Web Services Description Language file format to provide the ability to create a standard for JSON based web services that is both structured using the lessons learned from years of building SOAP web services and utilizing the best innovations such as JSON (with REST compatibility) to build a more robust web service standard. One of the puzzle peices is building a description of the web services themselves that can be consumed in a friendly way.

### ANATOMY OF A JWSDL

services (shorthand: "s")
service names (0 .. n names listed)
description (shorthand: "d") Required description of the web service
location (shorthand: "l") Required location of the web service
verb (shorthand: "v") Optional, defaults to GET and POST if not stated. Multiple verbs can be listed by using "verb":{"POST","GET"} .. etc. Best practice would dictate using standardized RESTful methods (noted below).  
parameters (shorthand: "p") Optional, arguments passed to the web service. If options are required they should be listed.
field names (0 .. n names listed)
datatype (shorthand: "dt") Recommended. Using the standard database data types.
default (shorthand: "d") Recommended, default value if none is provided
required (shorthand: "r") Recommended, bool value denoting requirement
returns (shorthand: "r") Optional, expected values the web service should pass back in the body of a returned envelope. 
field names (0 .. n names listed)
datatype (shorthand: "dt") Recommended. Using the standard database data types.
default (shorthand: "d") Recommended, default value if none is provided
required (shorthand: "r") Recommended, bool value denoting requirement


### JWSE ANATOMY

The basic structure is as follows


head (shorthand: "h")
service (shorthand: "s"): Required. Service origin URI to be called.
code (shorthand: "c"): Required. Response code of the service (not present in the client request). The code should utilize a standard HTTP status message.
message (shorthand: "m"): Recommended. Human readable description of the success or error.
reference (shorthand: "r"): Recommended, reference another header / body element.
mediatype (shorthand: "mt"): Recommended if different than "text/html"
body (shorthand: "b"): data returned from the request (if any)
