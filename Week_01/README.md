### Week 1 code examples

**sep02v1**

Results from doing File > New > Project. 
Unmodified, no changes. 
Study its structure - this is a typical ASP.NET MVC project.

**sep02v2**

Creates an in-memory data store, a simple generic list of colours.
This app features:
- an in-memory data store</li>
- the store is a 'per-request' store - it gets created when the controller is instantiated, and it is discarded after the request has been serviced
- the store is a simple generic list of strings (of colours)
- as a bonus feature, ajax.html will call the web service, and use the results to modify the web page

**sep02v3**

Adds an app domain data model (colours), an initializer, and a data service class.
This app's features:
- in-memory data store
- the data store is in 'application state'
- as a result, it has a lifetime of at least 20 minutes
- the app also has a data model (i.e. a Colour class)
- it also has a data store initializer (to create initial data for the app)
- a data service (aka 'manager') class handles data operations
- a new controller was created to service the web requests
