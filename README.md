# About the Project

This project demonstrates fundamental and intermediate C# programming concepts through a practical, real-world application. Built as a console-based inventory management system, it emphasizes clean architecture, algorithmic thinking, and design pattern implementation.

## What You'll Find Here

- **Pure C# Implementation**: No external NuGet packages—focused entirely on clean code, proper structure, and core language features
- **Multiple Data Structures**: Practical usage of `Dictionary`, `List`, `LinkedList`, `Stack`, `Queue`, `Graph`, and `PriorityQueue`
- **Algorithm Implementations**: Custom sorting (quicksort, mergesort), searching (binary, linear), and graph traversal (BFS/DFS) algorithms
- **Design Pattern Showcase**: Real-world application of industry-standard patterns

## Architecture & Design Patterns

### Structural Patterns

- **Model-View-Controller (MVC)**
  - **Models**: Domain entities decoupled from presentation logic
  - **Views**: Handle all user interactions and input validation
  - **Controllers**: Orchestrate communication between Views and Services

- **Service-Repository**
  - **Services**: Encapsulate business logic and application rules
  - **Repository**: Abstract data persistence layer for clean separation of concerns

### Creational Patterns

- **Singleton**: `DbContext` class manages in-memory data persistence with a single instance throughout runtime
- **Factory Method**: Dynamic creation of products and transactions

### Behavioral Patterns

- **Strategy**: Runtime selection of sorting and searching algorithms
- **Observer**: Event-driven notifications for stock and price changes
- **Command**: Undo/Redo functionality for transactions

---

## 📋 Methodology

This project was developed following a structured, professional approach to simulate real-world software development practices.

### Development Process

1. **Requirements Gathering**: Generated a comprehensive project specification using Generative AI (ChatGPT) to simulate a business case scenario
2. **Design & Planning**: Analyzed requirements and designed the architecture to incorporate multiple data structures, algorithms, and design patterns
3. **Implementation**: Built the solution incrementally, following SOLID principles and clean code practices
4. **Testing**: Validated functionality through manual testing and targeted scenarios

### Initial Prompt

> *"Write a description of a console program project for OOP using several different data structures and algorithms for me to practice C#. Make it professional level, but keep in mind that it's a console project. Also, force me to use defined design patterns."*

### AI-Generated Specification

The complete project specification (SmartMarket Console Inventory & Recommendation System) was generated through this prompt, providing clear technical requirements, mandatory data structures, required algorithms, and specific design patterns to implement.

This approach simulates how developers might work with product requirements or technical specifications in professional environments, translating business needs into technical solutions.

# 🧩 SmartMarket — Console Inventory & Recommendation System

## 🎯 Project Summary

Develop a console-based inventory and sales management system for a fictional small marketplace called **SmartMarket**. The system manages products, categories, customers, and transactions — while also providing recommendations and analytics using data structures and algorithms.

The goal is to practice clean architecture, object-oriented design, common data structures, algorithmic thinking, and core design patterns — all in a single cohesive project.

---

## 🧱 Core Requirements

### 1. Domain Objects

Implement at least the following core classes (with inheritance, composition, and encapsulation):

- **`Product`**
  - Fields: `Id`, `Name`, `Category`, `Price`, `StockQuantity`

- **`Category`**
  - Fields: `Id`, `Name`, `Description`

- **`Customer`**
  - Fields: `Id`, `Name`, `PurchaseHistory`

- **`Transaction`**
  - Fields: `Id`, `Customer`, `ProductList`, `TotalAmount`, `Date`

#### ➕ Optional (for extended realism)
- `Supplier`, `Discount`, or `Coupon`

Each class should have clear responsibilities, constructors, validation, and overridden `ToString()` methods.

---

## ⚙️ Functional Requirements

### 🛒 Core Features

- Add / Update / Remove products and categories
- Search products by name or category using different algorithms (binary search, linear search, etc.)
- Sort inventory by price, stock, or name using at least two sorting algorithms (e.g., quicksort, mergesort, insertion sort)
- Simulate transactions — customers buy products, reducing stock and generating a transaction record
- View reports:
  - Total revenue
  - Top-selling products
  - Out-of-stock alerts

### 💡 Advanced Features

- **Recommendation Engine**
  - Suggest products to a customer based on their purchase history
  - Use a graph structure to represent product relationships (edges = "frequently bought together")

- **Inventory Restocking Algorithm**
  - Use a priority queue (e.g., `SortedSet` or custom heap) to track products with low stock for automatic restocking

---

## 🧩 Data Structures You Must Use

| Feature | Data Structure |
|---------|----------------|
| Product storage | `Dictionary<int, Product>` |
| Product search | Binary Search / List |
| Category listing | `List<Category>` |
| Purchase history | `LinkedList<Transaction>` |
| Recommendations | `Graph` (adjacency list or matrix) |
| Low-stock tracking | `PriorityQueue` or `SortedSet` |
| Undo last transaction | `Stack<Transaction>` |
| Command history | `Queue<string>` |

---

## ⚙️ Algorithms You Must Implement

| Algorithm Type | Use Case |
|----------------|----------|
| Sorting | Sort products by price/name/stock |
| Search | Find a product efficiently |
| Graph Traversal (BFS/DFS) | Product recommendations |
| Greedy or Dynamic Programming | Inventory restock cost optimization |
| Hashing | Efficient product/customer lookup |

---

## 🧩 Required Design Patterns

| Pattern | Use Case |
|---------|----------|
| Singleton | `Database` or `DataStore` manager (simulate persistence) |
| Factory Method | Create products or transactions dynamically |
| Strategy | Choose sorting or searching algorithms at runtime |
| Observer | Notify subscribers when stock or prices change |
| Command | Implement Undo/Redo for operations (e.g., cancel last sale) |
| Repository (optional) | Separate business logic from data access layer |

---

## 🧰 Technical Guidelines

- **Language**: C# (.NET 8+ preferred)
- **Architecture**: N-layered console app (Presentation → Service → Repository → Model)
- **Code Style**: Follow SOLID principles
- **Testing**: Include at least a few unit tests (e.g., using `xUnit` or `NUnit`)
- **Persistence (optional)**: Store data in `.json` or `.csv` files for session persistence
