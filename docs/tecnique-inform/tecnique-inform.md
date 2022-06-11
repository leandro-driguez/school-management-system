
# **Tecnique Inform**

## School Management System

### Authors

* Laura Victoria Riera
* Marcos M. Tirador del Riego
* Leandro Rodriguez Llosa

## Data Dictionary

### AdditionalService

<table>
    <tr>
        <th>Key</th>
        <th>Name</th>
        <th>Type</th>
    </tr>
    <tr>
        <td>Private</td>
        <td>Id</td>
        <td>Guid</td>
    </tr>
    <tr>
        <td></td>
        <td>Worker</td>
        <td>Worker</td>
    </tr>
    <tr>
        <td></td>
        <td>Resource</td>
        <td>Resource</td>
    </tr>
    <tr>
        <td></td>
        <td>Worker porcentage profits</td>
        <td>integer</td>
    </tr>  
</table>

### BasicMean

<table>
    <tr>
        <th>Key</th>
        <th>Name</th>
        <th>Type</th>
    </tr>
    <tr>
        <td>Private</td>
        <td>Id</td>
        <td>Guid</td>
    </tr>
    <tr>
        <td></td>
        <td>Price</td>
        <td>integer</td>
    </tr>
    <tr>
        <td></td>
        <td>Type</td>
        <td>string</td>
    </tr>
    <tr>
        <td></td>
        <td>Origin</td>
        <td>string</td>
    </tr>
    <tr>
        <td></td>
        <td>Devaluation in time</td>
        <td>integer</td>
    </tr>
    <tr>
        <td></td>
        <td>Inauguration date</td>
        <td>DateTime</td>
    </tr>
    <tr>
        <td></td>
        <td>Description</td>
        <td>string</td>
    </tr>
</table>

### Classroom

<table>
    <tr>
        <th>Key</th>
        <th>Name</th>
        <th>Type</th>
    </tr>
    <tr>
        <td>Private</td>
        <td>Id</td>
        <td>Guid</td>
    </tr>
    <tr>
        <td></td>
        <td>Name</td>
        <td>string</td>
    </tr>
    <tr>
        <td></td>
        <td>Capacity</td>
        <td>integer</td>
    </tr>
</table>

### Course

<table>
    <tr>
        <th>Key</th>
        <th>Name</th>
        <th>Type</th>
    </tr>
    <tr>
        <td>Private</td>
        <td>Id</td>
        <td>Guid</td>
    </tr>
    <tr>
        <td></td>
        <td>Price</td>
        <td>int</td>
    </tr>
    <tr>
        <td></td>
        <td>Type</td>
        <td>string</td>
    </tr>
    <tr>
        <td></td>
        <td>Name</td>
        <td>string</td>
    </tr>
</table>

### CourseGroup

<table>
    <tr>
        <th>Key</th>
        <th>Name</th>
        <th>Type</th>
    </tr>
    <tr>
        <td>Private</td>
        <td>Id</td>
        <td>Guid</td>
    </tr>
    <tr>
        <td></td>
        <td>Course</td>
        <td>Course</td>
    </tr>
    <tr>
        <td></td>
        <td>Capacity</td>
        <td>integer</td>
    </tr>
    <tr>
        <td></td>
        <td>Start date</td>
        <td>DateTime</td>
    </tr>
    <tr>
        <td></td>
        <td>End date</td>
        <td>DateTime</td>
    </tr>
    <tr>
        <td></td>
        <td>Current teacher</td>
        <td>Worker</td>
    </tr>
</table>

### Expense

<table>
    <tr>
        <th>Key</th>
        <th>Name</th>
        <th>Type</th>
    </tr>
    <tr>
        <td>Private</td>
        <td>Id</td>
        <td>Guid</td>
    </tr>
    <tr>
        <td></td>
        <td>Category</td>
        <td>string</td>
    </tr>
    <tr>
        <td></td>
        <td>Description</td>
        <td>string</td>
    </tr>
</table>

### ExpenseRecord

<table>
    <tr>
        <th>Key</th>
        <th>Name</th>
        <th>Type</th>
    </tr>
    <tr>
        <td>Private</td>
        <td>Id</td>
        <td>Guid</td>
    </tr>
    <tr>
        <td></td>
        <td>Expense</td>
        <td>Expense</td>
    </tr>
    <tr>
        <td></td>
        <td>Date</td>
        <td>DateTime</td>
    </tr>
    <tr>
        <td></td>
        <td>Amount</td>
        <td>integer</td>
    </tr>
    <tr>
        <td></td>
        <td>Value</td>
        <td>int</td>
    </tr>
</table>

### Position

<table>
    <tr>
        <th>Key</th>
        <th>Name</th>
        <th>Type</th>
    </tr>
    <tr>
        <td>Private</td>
        <td>Id</td>
        <td>Guid</td>
    </tr>
    <tr>
        <td></td>
        <td>Name</td>
        <td>string</td>
    </tr>
</table>

### Resource

<table>
    <tr>
        <th>Key</th>
        <th>Name</th>
        <th>Type</th>
    </tr>
    <tr>
        <td>Private</td>
        <td>Id</td>
        <td>Guid</td>
    </tr>
    <tr>
        <td></td>
        <td>Name</td>
        <td>string</td>
    </tr>
    <tr>
        <td></td>
        <td>Category</td>
        <td>string</td>
    </tr>
    <tr>
        <td></td>
        <td>Price</td>
        <td>integer</td>
    </tr>
</table>

### Schedule

<table>
    <tr>
        <th>Key</th>
        <th>Name</th>
        <th>Type</th>
    </tr>
    <tr>
        <td>Private</td>
        <td>Id</td>
        <td>Guid</td>
    </tr>
    <tr>
        <td></td>
        <td>Duration</td>
        <td>Time</td>
    </tr>
    <tr>
        <td></td>
        <td>Start date</td>
        <td>DateTime</td>
    </tr>
    <tr>
        <td></td>
        <td>DayOfWeek</td>
        <td>integer</td>
    </tr>
</table>

### SchoolMember

<table>
    <tr>
        <th>Key</th>
        <th>Name</th>
        <th>Type</th>
    </tr>
    <tr>
        <td>Private</td>
        <td>Id</td>
        <td>Guid</td>
    </tr>
    <tr>
        <td></td>
        <td>CardId</td>
        <td>string</td>
    </tr>
    <tr>
        <td></td>
        <td>Name</td>
        <td>string</td>
    </tr>
    <tr>
        <td></td>
        <td>Last name</td>
        <td>string</td>
    </tr>
    <tr>
        <td></td>
        <td>Phone number</td>
        <td>int</td>
    </tr>
    <tr>
        <td></td>
        <td>Address</td>
        <td>string</td>
    </tr>
    <tr>
        <td></td>
        <td>Date becommed member</td>
        <td>DateTime</td>
    </tr>  
</table>


### Shift

<table>
    <tr>
        <th>Key</th>
        <th>Name</th>
        <th>Type</th>
    </tr>
    <tr>
        <td>Private</td>
        <td>Id</td>
        <td>Guid</td>
    </tr>
    <tr>
        <td></td>
        <td>Shift classroom</td>
        <td>Classroom</td>
    </tr>
    <tr>
        <td></td>
        <td>Shift schedule</td>
        <td>Schedule</td>
    </tr>
    <tr>
        <td></td>
        <td>Course group</td>
        <td>CourseGroup</td>
    </tr>
</table>

### Student

<table>
    <tr>
        <th>Key</th>
        <th>Name</th>
        <th>Type</th>
    </tr>
    <tr>
        <td>Private</td>
        <td>Id</td>
        <td>Guid</td>
    </tr>
    <tr>
        <td>Foreign</td>
        <td>Tuitor Id</td>
        <td>Guid</td>
    </tr>  
    <tr>
        <td></td>
        <td>Name</td>
        <td>string</td>
    </tr>
    <tr>
        <td></td>
        <td>Last names</td>
        <td>string</td>
    </tr>
    <tr>
        <td></td>
        <td>Phone number</td>
        <td>int</td>
    </tr>
    <tr>
        <td></td>
        <td>Address</td>
        <td>string</td>
    </tr>
    <tr>
        <td></td>
        <td>Date becommed member</td>
        <td>DateTime</td>
    </tr>  
    <tr>
        <td></td>
        <td>Founds</td>
        <td>int</td>
    </tr>
    <tr>
        <td></td>
        <td>Scholarity level</td>
        <td>Education</td>
    </tr>  
</table>

### StudentGroupRelation

<table>
    <tr>
        <th>Key</th>
        <th>Name</th>
        <th>Type</th>
    </tr>
    <tr>
        <td>Private</td>
        <td>Id</td>
        <td>Guid</td>
    </tr>
    <tr>
        <td></td>
        <td>Student</td>
        <td>Student</td>
    </tr>
    <tr>
        <td></td>
        <td>Course group</td>
        <td>CourseGroup</td>
    </tr>
    <tr>
        <td></td>
        <td>Start date</td>
        <td>DateTime</td>
    </tr>
    <tr>
        <td></td>
        <td>End Date</td>
        <td>DateTime</td>
    </tr>
</table>

## ==========================================

### StudentPaymentRecordForAdditionalService

<table>
    <tr>
        <th>Key</th>
        <th>Name</th>
        <th>Type</th>
    </tr>
    <tr>
        <td>Private</td>
        <td>Id</td>
        <td>text</td>
    </tr>
    <tr>
        <td></td>
        <td>StudentId</td>
        <td>text</td>
    </tr>
    <tr>
        <td></td>
        <td>ServiceId</td>
        <td>text</td>
    </tr>
    <tr>
        <td></td>
        <td>Date</td>
        <td>text</td>
    </tr>
</table>

### StudentPaymentRecordPerGroup

<table>
    <tr>
        <th>Key</th>
        <th>Name</th>
        <th>Type</th>
    </tr>
    <tr>
        <td>Private</td>
        <td>Id</td>
        <td>text</td>
    </tr>
    <tr>
        <td></td>
        <td>StudentId</td>
        <td>text</td>
    </tr>
    <tr>
        <td></td>
        <td>PaidCourseGroupId</td>
        <td>text</td>
    </tr>
    <tr>
        <td></td>
        <td>PaymentDate</td>
        <td>text</td>
    </tr>
</table>

### TeacherCourseRelation

<table>
    <tr>
        <th>Key</th>
        <th>Name</th>
        <th>Type</th>
    </tr>
    <tr>
        <td>Private</td>
        <td>Id</td>
        <td>text</td>
    </tr>
    <tr>
        <td></td>
        <td>TeacherId</td>
        <td>text</td>
    </tr>
</table>

### 

<table>
    <tr>
        <th>Key</th>
        <th>Name</th>
        <th>Type</th>
    </tr>
    <tr>
        <td>Private</td>
        <td>Id</td>
        <td>Guid</td>
    </tr>
    <tr>
        <td></td>
        <td></td>
        <td></td>
    </tr>
</table>

### 

<table>
    <tr>
        <th>Key</th>
        <th>Name</th>
        <th>Type</th>
    </tr>
    <tr>
        <td>Private</td>
        <td>Id</td>
        <td>Guid</td>
    </tr>
    <tr>
        <td></td>
        <td></td>
        <td></td>
    </tr>
</table>

### 

<table>
    <tr>
        <th>Key</th>
        <th>Name</th>
        <th>Type</th>
    </tr>
    <tr>
        <td>Private</td>
        <td>Id</td>
        <td>Guid</td>
    </tr>
    <tr>
        <td></td>
        <td></td>
        <td></td>
    </tr>
</table>

### 

<table>
    <tr>
        <th>Key</th>
        <th>Name</th>
        <th>Type</th>
    </tr>
    <tr>
        <td>Private</td>
        <td>Id</td>
        <td>Guid</td>
    </tr>
    <tr>
        <td></td>
        <td></td>
        <td></td>
    </tr>
</table>




























### Tuitor

<table>
    <tr>
        <th>Key</th>
        <th>Name</th>
        <th>Type</th>
    </tr>
    <tr>
        <td>Private</td>
        <td>Id</td>
        <td>Guid</td>
    </tr>
    <tr>
        <td></td>
        <td>Name</td>
        <td>string</td>
    </tr>
    <tr>
        <td></td>
        <td>Phone number</td>
        <td>int</td>
    </tr>
</table>

### Worker

<table>
    <tr>
        <th>Key</th>
        <th>Name</th>
        <th>Type</th>
    </tr>
    <tr>
        <td>Private</td>
        <td>Id</td>
        <td>Guid</td>
    </tr>
    <tr>
        <td></td>
        <td>Name</td>
        <td>string</td>
    </tr>
    <tr>
        <td></td>
        <td>Last names</td>
        <td>string</td>
    </tr>
    <tr>
        <td></td>
        <td>Phone number</td>
        <td>int</td>
    </tr>
    <tr>
        <td></td>
        <td>Address</td>
        <td>string</td>
    </tr>
    <tr>
        <td></td>
        <td>Date becommed member</td>
        <td>DateTime</td>
    </tr>  
</table>





## App Layout Outline

jfladsjlfksd

## Class Schema Defined

sdklfjlkasjdf

## Others


# 😀

# 🔑

# 🪪

# 🗂️

### 📋 **Student**
Id text 
Tuitor: text 
Founds: integer 
ScholarityLevel: integer

| Atributes   |  Name   | Type |
|-------------|---------|------|
| Primary Key | Id      | text |
|             | Student | text |