### Week 2 code examples

**sep10v2**

This is our first code example that uses a persistent store.
This app features:
- Web.config connection string to a database server
- A data model with two associated class definitions
- A store initializer to create initial data (it gets executed via Global.asax.cs)
- View model classes to custom-shape the results

By the end of the class, we had defined some view model classes for one entity; we'll continue in the next class session.

>**Notice**
>
>We learned (in class) about a configuration issue with the College lab computers.
>Do not store your project in the default offered location in the File > New > Project dialog (because we don't have full file system permissions there).
>Instead, store it somewhere else - on your own media, or the Documents folder (or desktop) of the current logged-in user.

**sep13v1**

This code example fully implements the topics from week 2.
This app features:
- View model classes, designed with best-practice suggestions 
- The use of *repository* classes, which manage an entity (or entity group) 
- AutoMapper, which eliminates most property-to-property mapping code
