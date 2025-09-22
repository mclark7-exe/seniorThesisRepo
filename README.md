# Senior Thesis Repo: Silliam Shakespeare's Theatre "Simulator" (Working Title)
As a historic theatre's new owner and director, put on shows by running through a gauntlet of fast-paced microgames.

## Overall gameplay loop

The player selects the ‘showtime’ button to start the show
After a ‘3, 2, 1, GO’ countdown, the curtain opens, and a random unlocked microgame is started
Microgames are selected randomly but in rough chronological order
Short instructions, a timer, and an ‘audience reaction’ bar are shown on screen 
The audience reaction starts around one-third full at the beginning of the game but starts higher when the player buys decorations, achieves a higher reputation, and acquires more popular scripts
The player attempts to follow the onscreen instructions
The audience reaction bar rises if the player successfully follows the instructions or falls if they fail to do so before the timer reaches zero
Curtains close to cover the screen and open to a new microgame
The player continues to play microgames until either they complete a certain amount of them or the audience reaction bar empties completely
If the player fills the audience reaction bar completely during the show, they will enter an ‘encore,’ shown by a flashy pop-up at the end of the bar
If the player achieves an encore, the microgames will instead continue indefinitely until the player fails one more
A statistics screen shows:
The final audience reaction score- the final percentage of how full the bar is
How many tickets were sold, increased by a more popular script and a higher reputation
How much money was spent on the production, increased by a larger cast and crew, any marketing the player chooses to do, and any damage or accidents caused by failing certain microgames
How much money was made, increased by a higher audience reaction bar and ticket sales
a one-to-five-star rating, given depending on the audience reaction score, how much money was made, and whether the player achieved an encore
An excerpt from a critic's review of the show, randomly picked based on star rating
player taps the ‘curtain call’ button to return to the theatre


## Introduction

### Purpose
The purpose of this document is to outline the functional and non-functional requirements of Mahoney University’s new online registration system. The system is designed to streamline the registration process for students and faculty, replacing the outdated manual system. This specification serves as a contract between the system stakeholders and the developers to ensure that the system meets the needs of its users while adhering to university policies and technical constraints.

The key goals of the new system are:
- To improve the efficiency of the course registration process for students.
- To provide staff in the Registrar’s Office with tools to manage course offerings, schedules, and student records.
- To enhance the accuracy and accessibility of student academic information, such as grades and enrollment history.
- To support the university’s transition to digital infrastructure while maintaining compatibility with legacy systems during a transitional period.

### Scope
This system is intended to support the registration process for all students at Mahoney University, including undergraduates, graduate students, and non-degree-seeking students. The system will handle:
- Student authentication and secure access to personal records.
- Course search and registration.
- Enrollment validation, including prerequisite checks and course availability.
- Management of student schedules, including the ability to add, drop, or modify course enrollments.
- Grade viewing and transcript requests.

The scope of the system also includes administrative tools for the Registrar’s Office to:
- Create and modify course offerings for each academic term.
- Manage enrollment caps, waitlists, and course prerequisites.
- Track student progress and generate reports for academic performance.

### Definitions, Acronyms, and Abbreviations
- **Registrar**: The official responsible for maintaining student records, managing course schedules, and overseeing the registration process.
- **Student Information System (SIS)**: A university-wide database that stores student records, course information, and academic data.
- **GPA**: Grade Point Average, a numerical representation of a student's academic performance.
- **Semester**: A division of the academic year, typically consisting of a Fall and Spring term, in which courses are offered and completed.
- **Waitlist**: A system that allows students to reserve a spot in a full course, subject to availability if another student drops the course.
- **Prerequisite**: A course or requirement that must be completed before a student can enroll in a more advanced course.
- **User Role**: A designation for system access levels, such as student, registrar, or faculty member, each with different permissions within the system.
- **Concurrent Enrollment**: The ability for students to be enrolled in multiple courses during the same academic term.

## Overview
The Mahoney University Registration System is a web-based platform designed to automate the course registration process for students and faculty. It serves as the primary interface for students to manage their academic schedules and for university staff to oversee the course offerings and registration workflows.

### System Features:
1. **Secure Login**: Ensures that only authorized users (students, faculty, and staff) have access to the system, with user authentication based on university credentials.
2. **Course Search**: Allows students to browse available courses by department, term, and subject, with filtering options based on course availability, schedule, and prerequisites.
3. **Course Registration**: Students can add or drop courses, view class schedules, and receive notifications of any conflicts or unmet prerequisites.
4. **Grades and Transcripts**: Provides students with access to their grades from current and past semesters, as well as the ability to request official transcripts.
5. **Registrar Management Tools**: The Registrar’s Office can create, modify, and delete course sections, set enrollment limits, and manage waitlists.

The system is designed with scalability in mind, allowing it to handle thousands of students registering simultaneously during peak periods. It will integrate with the university’s existing Student Information System (SIS) and is built using modern web technologies to ensure ease of use, reliability, and performance.

The following sections detail the specific use cases that the system will support, describing how students and staff will interact with the system during typical operations.

## Use Cases

### Use Case 1.1: Secure Login
- **Actors**: Student or registrar
- **Overview**: Actor uses password to verify their identity.

**Typical Course of Events**:
1. Page prompts for username and password.
2. User enters their username and password and hits enter/login.
3. System verifies that the username and password are correct.

**Alternative Courses**:
- **Step 3**: User and/or password are not correct.
  1. Displays error.
  2. Go back to step 1.

### Use Case 1.2: Find a Course
- **Actors**: Student
- **Overview**: Student finds a desired class.

**Typical Course of Events**:
1. Run Use Case 1.1, *Secure Login*.
2. Displays list of current and upcoming semesters.
3. Student selects a semester.
4. Displays departments actively offering courses in that semester.
5. Student selects a department.
6. Displays courses of that department from that semester that are currently offered.
7. Student selects a course.
8. Displays course details.

**Alternative Courses**:
- Any step: Student can start a new search at any time
  1. Student clicks "start new search."
  2. Go back to step 2.

### Use Case 1.3: Register for a Course
- **Actors**: Student
- **Overview**: Student registers for a course.

**Typical Course of Events**:
1. Run Use Case 1.2, *Find a Course*.
2. Student clicks on "register for course" button.
3. Verify that student can take the course.
4. Display "You have successfully registered for 'insert course name here'."

**Alternative Courses**:
- **Step 4**: Student can't take course
  1. Displays "You cannot take this course, please contact the registrar for further information."

### Use Case 1.4: Check Grades
- **Actors**: Student
- **Overview**: Student checks grades.

**Typical Course of Events**:
1. Run Use Case 1.1, *Secure Login*.
2. Display previous semesters in which the student took course(s).
3. Student selects semester.
4. Displays courses and grades.

### Use Case 1.5: Registrar Creates Sections
- **Actors**: Registrar
- **Overview**: Registrar creates section.

**Typical Course of Events**:
1. Run Use Case 1.1, *Secure Login*.
2. Registrar selects "Create Section."
3. Display "Create Section" form.
4. Registrar submits form.
5. System verifies valid entry (no overlapping schedules/times).
6. Displays section details and successfully added.

**Alternative Courses**:
- **Step 6**: Entry invalid
  1. Display error.
  2. Go back to step 3.

### Use Case 1.6: Registrar Modifies Section
- **Actors**: Registrar
- **Overview**: Registrar modifies existing sections.

**Typical Course of Events**:
1. Run Use Case 1.1, *Secure Login*.
2. Registrar selects "Modify section."
3. Displays all sections (with order options).
4. Choose section.
5. Display "Edit Form" with filled-in data.
6. Submit/verify data.
7. Display "Section successfully edited."

**Alternative Courses**:
- **Step 7**: Invalid Data
  1. Display Error.
  2. Go back to step 5.
