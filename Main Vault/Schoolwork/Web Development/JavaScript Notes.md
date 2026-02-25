**OVERVIEW**
	javascript is inlcuded in HTML files by using the \<script\> tag. 
	It should go after the body, so that the page loads the HTML before the JavaScript
	Directives tell the JavaScript engine how to interpret and compile your code.


**DIRECTIVES**
- Use Strict (good practice)
	- "Use Strict";


**Fetch API**
- Requests data from a url
- Then you can use .then to wait until it's finished requesting
- You can convert the results to json with .json
- That will give you usable data


**LIBRARIES**
- Math
	- Round
	- Ceil
	- Floor
	- Trunc
	- Pow
	- Sqrt
	- PI
	- min
	- max
	- random
- Window
	- alert("message")
- Document
	- querySelector('#ID');
		- returns the element of the input ID
		- const value_1 = parseFloat(document.querySelector('#num1').value);
	- quierySelectorAll('#ID')
	- You can querySelect within DOM elements to search their children
	- createElement(element)
	- createTextNode(value)
- DOM Element
	- addEventListener
		- Listens for an event and runs a function
		- document.querySelector("#add_button").addEventListener("click", add);
			- This finds the button with the ID add_button and runs the function add on click
	- innerHTML
		- Lets you directly set what's inside the element
		- document.querySelector("#result").innerHTML = sum;
			- This sets the element with the ID result to a variable called sum
	- parentNode
	- childNodes
	- firstChild
	- lastChild
	- nextElementSibling
	- textContent
	- hasAttribute(name)
	- getAttribute(name)
	- setAttribute(name, value)
	- removeAttribute(name)
	- id
	- title
	- name
	- value
	- classList
		- Gets an object that contains the class names in the class attribute and provides properties and methods for working with them
		- length 
		- value
		- contains(className)
		- add(className)
		- remove(className)
		- replace(oldName, newName)
		- toggle(className)
	- className
	- a
		- href
	- radio buttons / check boxes
		- checked
	- img
		- src
		- alt
		- width
		- height
	- input
		- disabled
	- form
		- section. URL of the file that will process the data in the form
		- method. the Http method for submitting the form data. It can be set to either get or post. The default value is get.
		- submit()
		- reset()
	- controls
		- focus()
		- blur()
		- select()
	- control events
		- click
		- dblclick
		- focus
		- blur
		- change
		- select
	- appendChild(node)
	- insertBefore(new, child)
	- replaceChild(node)
	- remove()
- Array (declared with \[])
	- Push (elements)
		- Adds one or more elements to the end of the array and returns the new length
	- Pop () 
		- removes the last element, and returns the value of the removed element
	- Unshift (elements)
		- Adds one or more elements to the beginning of the array, shifts all other elements to the right, returns the new length of the array
	- Shift()
		- Removes the first element, shifts all elements on index to the left, returns value of removed element
	- Splice(start, number, elements) 
		- removes the number of elements specified by the second parameter. Replaces the removed elements with the ones in the optional third parameter, or adds the elements at the start index if the second parameter is 0. 
	- Splice (start, end) 
		- returns a new array from the start index to the element before the end index. 
	- Index of (value, start)
	- Last index of (value, start)
	- Includes (value, start)
	- At (index)
	- Join (separator)
	- To String()
	- Reverse()
	- Length
	- Startswith
	- Endswith
	- Includes
- Strings
	- At(position)
	- Indexof(search, start)
	- Startswith(search)
	- Endswith(search)
	- Includes(search, start)
	- substring(start, end)
	- toLowerCase
	- ToUpperCase
	- Trimstart
	- TrimEnd
	- Trim
	- Padstart(length)
	- Padend(Length)
	- Replace(old, new)
	- ReplaceAll(old, new)
	- Repeat(times)
	- Split(separator)


**TIME**
- Dates
	- Represented by the number of milliseconds since midnight, Jan 1st 1970
	- Make sure to use "new Date()" instead of just "Date()"
	- Date()
		- Creates a new Date object set to the current time
	- Date(string)
		- Creates a new Date object set to the date and time of the string
	- Date(numbers)
		- Creates a new Date object set to the year, month, day, hours, minutes, seconds, and milliseconds of the numbers
	- Date(date)
		- Creates a new Date object that's a copy of the Date object it received
	- Date(timestamp)
		- Creates a new Date object set to the milliseconds since midnight, Jan 1, 1970
	- Date().toString()
		- Creates a string representing the date and time in local time using the client's time zone
	- Date().toDateString()
		- Creates a string representing just the date in local time
	- Date().toTimeString()
		- Creates a string representing just the time in local time
	- Date().toISOString()
		- Creates a string representing the date and time in universal time
	- Date().getTime()
		- Returns number of milliseconds since midnight, Jan 1, 1970
	- Date().getFullYear()
	- Date().getMonth()
	- Date().getDate()
	- Date().getDay()
	- Date().getHours()
	- Date().getMinutes()
	- Date().getSeconds()
	- Date().getMilliseconds()
	- Date().setFullYear(year)
	- Date().setMonth(month)
	- Date().setDate(day)
	- Date().setHours(hour)
	- Date().setMinutes(minutes)
	- Date().setSeconds(seconds)
	- Date().setMilliseconds(ms)
	- EXAMPLE CODE
			````const date_el = document.getElementById("birthday-input");
			let date = new Date(date_el.value);
			console.log(date);````
- Timers
	- setTimeout(function, delay)
		- Calls the function after the delay in milliseconds has passed
	- clearTimeout(timer)
		- Cancels a timer created by the setTimeout() method
	- setInterval(function, interval)
		- Calls the function repeatedly each time the specified interval has passed
	- clearInterval(timer)
		- Cancels a timer created by the setInterval() method
	- Example Code
		- let timer = null;
		- timer = setInterval(update, 1000);
		- clearInterval(timer);


**DATA VALIDATION**
- HTML Data Validation
	- Input
		- Type
			- email
			- url
			- tel
			- number
			- range
			- data
			- time
		- autofocus
			- tells the browser to set the focus to the control when the page is loaded
		- placeholder
			- a message in the control that is removed when an entry is made by the user
		- required
		- title
			- text that is displayed in a tooltip when the mouse hovers over it
		- pattern
		- novalidate
		- autocomplete
	- checkValidity()
		- Returns true if all the data in a form or element is valid
	- validationMessage
		- A property that gets a string for the browser's standard validation message
	- setCustomValidity(msg)
		- Sets a custom validation message for the element. 
		- To remove a previous validation message, set an empty string
- Try Catch / Errors
	- Error Properties
		- name
		- message
	- Types of Errors
		- Error
		- RangeError
			- Number exceeded allowable range
		- TypeError
			- The type of value is different from what was expected
```
try { statements }
catch(error) { statements }
finally { statements } // optional
```

**STATEMENTS**
- Document.write("MESSAGE")
- console.log()
- typeof var
- let name = value;
- const name = value;
- setTimeout(() => {}, 2000);
- Number()
- ToFixed()
- prompt("message", default value)
- parseInt(string) & parseFloat(string)
	- Can return NaN or Not a Number


**FUNCTIONS**
```
function name (parameters) {
	// code
}
```
- Must be declared before use
- Arrow function
	- Just a worse version of a function I don't know what purpose this serves
- Rest and Spread operators
	- Collects one or more values into an array
	- Useful for functions with varying parameters
	- Put an ellipsis before a parameter name basically 

**VARIABLES**
- Const or Let for declaration
- \[] after variable name for arrays
	- You can set the length of an array directly which is insanely powerful


**EVENTS**
- Window.load
	- Whole page has been loading into the browser
- document.DOMContentLoaded
	- The HTML doc is loaded and ready
- element.keydown
	- User presses a key
- element.keyup
	- User releases a key
- element.click
	- User clicks on the element
- element.dbclick
	- User double clicks on the element
- element.mouseover
	- User moves mouse over the element
- element.mousein
	- User moves the mouse into the element
- elemenet.mouseout
	- User moves the mouse out of the element
**USING EVENTS**
- addEventListener(event, function)
- removeEventListener(event, function)

**ETC**
- JavaScript is included in HTML files with the \<script> tag
	- It's best practice to placed this after the body
	- Load JavaScript after HTML
- Absences of values are set to undefined by default.
	- Absences of values are set to null by the programmer
	- Values are only set to null if the programmer intends it
- You can iterate through each value in an array with for of loop
