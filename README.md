# Saving Variables

For this exercise you will create a CLI application that will Read, Delete and Create entries within a database.

The goal of this project is to help students learn TDD with the Entity Framework and Moq. Students will be supplied a trivial ERD and Command Line Application with this project.

This solution contains:

1. Console Project
2. Unit Test Project


## Rules

- Create a model and matching migration for saving variables  usign created or supplied ERD.
- Implement the Repository Pattern
- There should be Unit Tests on all classes and methods you create.
- Your solution should have at least 2 total projects. Unit Tests should be in it's own project.
- This is an OOP focused class. Therefore, there will be classes. Your `Program` class and `Main` method should only be responsible for receiving user input and printing output.
- If a user submits an incomplete command or expression, the application should **not** attempt to evaluate it but print out a useful message.

## Overview of how it should work

Starting your console application should create a prompt that looks like:

```sh
>> 
```

The user will enter expressions or commands that do work on a backend database.

## Features

### General Commands

Your application should accept the following commands:

- `lastq` - prints the last entered command or expression **even if it was unsuccessful**.
- `quit` and `exit` - exits the program

### Variable Expressions

Variables have one character length names that holds a positive or negative integer.Relative to variable, your our application should support the following expressions and commands:

- `a = 4` - creates an entry in the database where `a` is `4`
- `clear a`, `remove a` and `delete a` - removes the saved entry for `a` from the database


```sh
>> x = 3
   = saved 'x' as '3'
>> x
   = 3
>> x = 4
   = Error! 'x' is already defined!
>> clear x
   = 'x' is now free!
>> x = -4
   = saved 'x' as '-4'
>> exit
   Bye!!!
```

### Database Commands

- `clear all`, `remove all` and `delete all` - removes all saved entries from the database
- `show all` - prints out all variables (with their values) in tabular form saved within the database. Note: Variables should be listed in alphabitcal order. See example below.

```sh
>> x = 3
   = saved 'x' as '3'
>> b = 4
   = saved 'b' as '4'
>> show all
   Name -> Value
   b -> 3
   x -> 4
>> clear all
   = deleted all items from database!
>> show all
   = Database empty! Nothing to show.
>> quit
   Bye!
```

## Challenges

The following are optional and stretch goals for those who finish this exercise early and want to move to greater heights. These Challenges are not required and can be completed in any order.

### Better `show all` read-out

Re-implement the `show all` to display variables in the format:

```sh
>> show all
    ______________
   | Name | Value |
   |--------------|
   |  b   |   3   |
   |  x   |   4   |
   |______|_______|
```

### Provide a `help` General Command

`help` - prints out all the General and Database commands.

Be sure to print the commands with their respective meanings. Alphabetize via the command name. All commands should be printed in the following format:

```sh
>> help
   show all: prints out all variables (with their values) in tabular form saved within the database
   lastq: prints the last entered command or expression **even if it was unsuccessful**.
   quit|exit: exits the program
```

For commands that have multiple names, like `quit|exit`, you must display all alternate names for the command like demonstrated above. Alphabetize on the command name you display first.
