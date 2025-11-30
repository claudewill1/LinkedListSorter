# LinkedListSorter

A .NET 8 console application that demonstrates how to build, traverse, and sort a singly linked list.  
The project uses Test Driven Development and includes a full MSTest project for validating linked list behavior such as insertion, ascending sort, and descending sort.

---

## Features

- Singly linked list implementation
- Methods to insert values and convert the list to an array
- Sorting in ascending order
- Sorting in descending order
- Clean folder organization under src and tests
- Unit tests using MSTest
- Built with .NET 8
- Structured for Test Driven Development

---

## Project Structure

LinkedListSorter/
│
├── src/
│ └── LinkedListSorter.App/
│ ├── LinkedList/
│ │ ├── Node.cs
│ │ └── SinglyLinkedList.cs
│ ├── Services/
│ │ └── SortingService.cs
│ ├── Utilities/
│ │ └── InputUtility.cs
│ ├── Program.cs
│ └── LinkedListSorter.App.csproj
│
└── tests/
└── LinkedListSorter.Tests/
├── SinglyLinkedListTests.cs
└── LinkedListSorter.Tests.csproj


---

## Requirements

- .NET 8 SDK  
- Git Bash, PowerShell, or any supported shell environment

---

## Setup Instructions

### 1. Clone the repository

```bash
git clone <your-repo-url>
cd LinkedListSorter
