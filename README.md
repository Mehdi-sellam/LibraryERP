# Insight Library Management System Documentation

## Technologies Used:
- **C#**
- **.NET**
- **Forms**
- **MS Visual studio Internal Database**
- **Microsoft Visual Studio 2022** (Development environment)

### Contents:
1. [Introduction](#1-Introduction)
2. [Literature Review](#2-Literature-Review)
3. [Interface Design](#3-Interface-Design)
   - [Registration Form](#31-Registration-Form)
   - [Login Form](#32-Login-Form)
   - [The Work Interface Form](#33-The-Work-Interface-Form)
4. [Data Storage](#4-Data-Storage)
5. [Program Functionality (ERD)](#5-Program-Functionality-(ERD))
6. [References](#6-References)
7. [Usage](#Usage)

---

## 1. Introduction
This report covers the experience in designing, developing, and implementing a library management system built as a Windows desktop application using C# and Microsoft Visual Studio. The project, named **Insight Library**, utilized Windows Forms and a service-based database to build the system. The system allows the registration of new librarians and login functionality to add books and clients' details through three MS Windows forms: **Register**, **Login**, and **Work Interface**. 

The system stores data in a local database, enabling librarians to add borrowing orders to the database with unique book and client references, as well as the librarian's username. This documentation covers a comprehensive analysis of the system's interface design, database design, class implementation, and program functionality.

---

## 2. Literature Review
After determining the scope of the Windows desktop application, many examples with similar features and limitations were explored, particularly from platforms like YouTube. Several academic technologies and systems were also reviewed, including **LibraryThing**, **Koha**, and **Evergreen**, which are designed to manage library collections, client details, and borrowing orders (Brahmi and Nouali-Taboudjemat, 2019; Obeidat, 2019; Pishgooie, Zahedi, and Hamzehei, 2021).

Additionally, **LibraryWorld** was identified as a web-based library management system suitable for small and medium-sized libraries. Many features from LibraryWorld were incorporated into the Insight Library system (LibraryWorld, 2023).

---

## 3. Interface Design

### 3.1 Registration Form
The registration form allows the user, who will act as a librarian, to register with a unique username, password, full name, and license ID number. However, this form is not the first to appear after running the application. The login form appears first.

![image](https://github.com/user-attachments/assets/3dc6c9b7-7370-4d27-874d-d83fce60cc43)

[Diagram-Preview](<https://github.com/user-attachments/assets/3dc6c9b7-7370-4d27-874d-d83fce60cc43>)


---

### 3.2 Login Form
Upon running the application, the first interface displayed is the login form. Users can either log in with existing credentials or create a new account by using the registration hyperlink, which opens the registration form.

![image](https://github.com/user-attachments/assets/047ddc91-8439-4857-adfb-bbea5f93c740)

[Diagram-Preview](<https://github.com/user-attachments/assets/047ddc91-8439-4857-adfb-bbea5f93c740>)


---

### 3.3 The Work Interface Form
Once logged in, the user is presented with the **Work Interface** form. This form allows the librarian to navigate through three main panels for managing **Books**, **Clients**, and **Borrowing Orders**. Each panel contains text boxes for input and management through four buttons: **Add**, **Update**, **Clear**, and **Delete**. Data is displayed using a data grid view for ease of navigation and management.

![image](https://github.com/user-attachments/assets/2897e5be-af67-4589-8a85-699bde754dcb)

[Diagram-Preview](<https://github.com/user-attachments/assets/2897e5be-af67-4589-8a85-699bde754dcb>)


---

## 4. Data Storage
The Insight Library Management System uses a service-based database for storing data locally. The system handles book details, client information, and borrowing orders, ensuring that the data is properly organized and retrievable as needed.

### Data Storage Diagram

![image](https://github.com/user-attachments/assets/ba55afa8-6fda-4f45-8654-cec2ddc723ba)

[Diagram-Preview](<https://github.com/user-attachments/assets/ba55afa8-6fda-4f45-8654-cec2ddc723ba>)


---

## 5. Program Functionality (ERD)

The Insight Library system primarily revolves around one form for the work interface, where the majority of event handling takes place. Although the class structure is not clearly organized due to the reliance on one form, the following class diagram illustrates how the system could have been more efficiently organized. Future modifications are planned to improve the class structure.




![image](https://github.com/user-attachments/assets/7872b4bc-16d6-4336-9630-43e4724c6ca1)

[Diagram-Preview](<https://github.com/user-attachments/assets/7872b4bc-16d6-4336-9630-43e4724c6ca1>)

---

## 6. References
- **Brahmi, F. Z., and Nouali-Taboudjemat, N. (2019)** 'Design and Implementation of a Digital Library Management System', *International Journal of Computer Science and Information Security*, 17(8), pp. 1-6.
- **Obeidat, R. (2019)** 'Library Management Systems (LMS) in Jordanian Academic Libraries: A Comparative Study', *Journal of Academic Librarianship*, 45(5), p. 102057.
- **Pishgooie, A. H., Zahedi, M. R., and Hamzehei, R. (2021)** 'Evaluation of Open-Source Integrated Library Systems in the Middle East: Koha and Evergreen', *Electronic Library*, 39(3), pp. 538-553.
- **LibraryWorld**. (n.d.). *LibraryWorld: Library Automation Simplified*. Retrieved from [https://www.libraryworld.com](https://www.libraryworld.com)



---
---
---



## Usage Guide

### Launching the System:
- After installation, launch the **Insight Library Management System** from your desktop or Start menu.

### Login or Register:
- On launch, the **Login Form** will appear. Enter your credentials if you already have an account.
- If you do not have an account, click on the **Register** link to create a new user account.

### Registering a Librarian:
- In the **Registration Form**, fill in your **Username**, **Password**, **Full Name**, and **License ID** to create a new librarian account.
- Submit the details and return to the login page.

### Work Interface:
- Once logged in, the **Work Interface Form** will be displayed.
- Use this form to manage **Books**, **Clients**, and **Borrowing Orders**. Each section allows you to **Add**, **Update**, **Clear**, or **Delete** data.

### Managing Books:
- In the **Books** section, input book details such as **Title**, **Author**, **ISBN**, etc., and click **Add** to include it in the database.

### Managing Clients:
- In the **Clients** section, input client information, such as **Name**, **ID**, and **Contact Details**, and click **Add** to store the client’s details.

### Managing Borrowing Orders:
- In the **Borrowing Orders** section, input details of the borrowing transaction, including **Book ID**, **Client ID**, and **Borrow Date**, and click **Add** to save the order.


