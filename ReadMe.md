This document includes information about ToDo:s and about rules for the code

-----------------------------------------------------
Rules

Rule 1: All Classess should be sealed by default (ONLY OPEN UP WHEN NEEDED)
- leads to perfomance gains
- better code
---------------
EditorConfig Rule
dotnet_diagnostic.CA1852.severity = warning

Source: 
Why? https://www.youtube.com/watch?v=d76WWAD99Yo&t=15s
Nick Chapsas: Why all your classes should be sealed by default in C#, Sep 12, 2022


//ToDo: 
Add more loggers and finish their implementations
Create benchmarks for them

* Fix Analyser, they do not seem to be running?


* S: Single Responsibility Principle (SRP)
	- every class, or similar structure, in your code should have only one job to do
* O: Open closed Principle (OCP)
	- A software module/class is open for extension and closed for modification
* L: Liskov substitution Principle (LSP)
	- You should be able to use any derived class instead of a parent class and have it behave in the same manner without modification
* I: Interface Segregation Principle (ISP)
	- 
* D: Dependency Inversion Principle (DIP)
- High-level modules/classes should not depend on low-level modules/classes. Both should depend upon abstractions. 

-------------------------------------------
Project Management

* North Star
- Learn about Concepts and best principles
- Showcase skills
- Learn about Project Management

Useful Charts
* Gantt Charts
* Cost-Benefit Analysis (Instead of Pro/Cons)

KPI (KEY PERFOMANCE INDICATORS)


-------------------------------------------


ToDo:

* Iteration Comparison
https://www.youtube.com/watch?v=jUZ3VKFyB-A&t=2s