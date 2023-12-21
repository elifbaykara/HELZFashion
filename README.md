# Team 6 HELZFashion Project
- This repository contains the HELZFashion project provided by YetGen Jump & Akbank Backend Education Program. 
- The details of the project, which we completed as Team 6, are provided below: ⇓

## Elif's part [![Elif](https://img.shields.io/badge/Elif-181717?style=for-the-badge&logo=github&logoColor=white)](https://github.com/elifbaykara)
- Account Management (Identity) : Users can create an account (Sign Up).
Users can log in (Login).
- Clothes Management (Clothes) : Add Clothes UI & List Clothes UI:
UI design has been completed.
-User Interface (UI)
Sign Up & Login UI, Login Screen Design, Add Clothes Screen Design, List Clothes Screen Design


## Livanur's Part  [![Livanur](https://img.shields.io/badge/Livanur-181717?style=for-the-badge&logo=github&logoColor=white)](https://github.com/livaae)
- Entities and Controller-Views: BrandController, CategoryController, ClothesController: Handles actions related to brands, categories and clothing items (e.g., adding, deleting, updating, displaying details). Models: ClothesAddBrandCategory: Associated brands and categories. Enums: ColorType, PaymentMethod and SizeType.
- Dependency Injection: Utilized to inject instances of TeamHELZDbContext into controllers, enabling interaction with the database.
- MVC (Model-View-Controller) Architecture: Implemented through controllers handling logic and views managing the presentation layer.
- Entity Framework Core: Employed for database interaction, querying entities, and managing relationships.
- Frontend Development: Mentioned creation of HTML/CSS files for structuring views aligned with the project's design.
- Design Collaborations: Indicated involvement in designing the Contact Us home page and aligning project components with the design.

## Zahide's Part [![Zahide](https://img.shields.io/badge/Zahide-181717?style=for-the-badge&logo=github&logoColor=white)](https://github.com/zahidedusgun)
- The domain zahidedusgun.com.tr was purchased for the mail verification process.
- DNS settings for the domain were configured, connecting it to the Resend system.
- The API KEY provided by Resend was added to the program.cs file in the MVC section of the project to facilitate the necessary Resend integration.
- Token parameters for user authentication processes were created in the AuthController section.
- In the Auth Controller section, information for the email confirmation to be sent to the user was inputted.
- Bootstrap and CSS were utilized to design the Navbar, Layout, Carousel, Accordion, and dropdown functionality for Navbar items on the frontend.
- Design elements such as the modal, card, and table displayed on the Home page were crafted using Bootstrap and CSS.
- The logo and visuals for the HELZ site were designed using Canva.


## Hatice's Part  [![Hatice](https://img.shields.io/badge/Hatice-181717?style=for-the-badge&logo=github&logoColor=white)](https://github.com/hatice-dvc)
- Add to Cart Feature: Users can easily add the clothes they want to purchase to their shopping carts. We created an entity called "Basket," storing the items users added to their carts in a list called "BasketItem." It holds the properties "Clothes" and "Quantity." A Basket Controller was established to manage user cart operations, enabling add-to-cart functionality.The SessionExtensions extension was used, providing extended methods for handling session data in C#. It was utilized for scenarios such as maintaining cart information and user sessions.Then we created the BasketAndOrderViewModel to consolidate users' shopping carts and order information into a single model. This allows users to fill out cart content, payment, and delivery details in the same form while shopping.

- Order Creation and Viewing Feature: Customers can purchase items added to their carts by selecting their preferred payment method.Placed orders can be viewed in a list format, displaying order items, order date, and payment method. An entity named "Order" was created, encompassing properties such as ShippingAddress, PaymentMethod, OrderDate, Status, OrderItems, and BasketId. Enum structures were used for PaymentMethod and Status, while OrderItems are of type Basket. An enum named "OrderStatus" was introduced to store order statuses (pending/shipped/delivered/cancelled). A PaymentMethod enum was created to manage payment methods (cash/credit card/debit card/bank transfer/other). An Order Controller was established to manage customer orders, containing methods for successfully completing orders (OrderSuccess), creating new orders, and deleting orders. Additionally, views for carts and orders were created.

## Issues and Solutions
In this project, we encountered several challenges related to the database. Here are the main issues and how these problems were addressed:
- Errors and File Path Issues:
We faced various errors in database operations.
Issues arose with file paths.
Solution:
A detailed investigation was conducted to fix errors and address file path problems.
Database Viewing Problem:
There were difficulties in viewing the created database.
Solution:
Meticulous work was done on the database connection and configuration.
File Conflicts and Conflict Resolution:
Some files conflicted in the project, resulting in conflicts.
Solution:
Conflict resolutions were performed via Git, and file conflicts were resolved.
Usage of Two Separate Databases:
Two separate databases were used in the project: HelzIdentity (for the Identity part) and TeamHelz (Project database).
Solution:
Necessary configurations were made to ensure compatibility between the two databases.
Necessity to Recreate Databases:
Due to issues with the databases, we had to delete and recreate them.
Solution:
The databases were deleted, configurations were reviewed, and the databases were recreated.
Dealing with these issues was a learning process to overcome challenges, gain more knowledge about database usage, and work on configuration improvements.
On the database side, we encountered several challenges, such as:
The inability to control the Session structure from the database (the database couldn't manage events in the session, causing errors as we used the cart in the order section).
Ensuring that orders belong to a single user.
Representing payment methods and order statuses as enums on the website and struggling with their display.
Facing difficulties in ensuring that shopping carts belong to different users.
Through collaboration within the team, assistance from online tutorials, research, and guidance from our instructors, we successfully resolved these issues.

## The interface of the project
![image](https://github.com/elifbaykara/HELZFashion/assets/141638184/283d4054-0fc3-4670-877f-6d07a3b71df0)
![image](https://github.com/elifbaykara/HELZFashion/assets/141638184/84f78f62-db54-46dc-93fb-b86aef815bc1)
![image](https://github.com/elifbaykara/HELZFashion/assets/141638184/9034368b-f34f-400f-a835-ac60fedb0134)
![image](https://github.com/elifbaykara/HELZFashion/assets/141638184/c19c2a28-6008-46de-bb0f-efbabf022779)
![image](https://github.com/elifbaykara/HELZFashion/assets/141638184/53fb2384-2c87-4ab3-8706-787a9d2989de)
![image](https://github.com/elifbaykara/HELZFashion/assets/141638184/f424ac49-9a66-4782-8f09-9e0af43e5393)
![image](https://github.com/elifbaykara/HELZFashion/assets/141638184/bd655ba9-83e9-433a-8437-b21e842bc9ae)
![image](https://github.com/elifbaykara/HELZFashion/assets/141638184/be00df45-d3ca-401c-814e-72d1c123f678)





