# Recruitment practical tasks

- Task_1 
    - Reverse a string,
    - Check if a word is a palindrome,
    - Count each letter in a given text,
    - Find the missing number in an arithmetic sequence that is stored in an array. Numbers stored in an array should be unique. Example1: input array [1,2] number 0 is missing. Example2: [3,0,2,1] number 4 is missing. Example3: [2] array is invalid - two elements are missing 0 and 1.
- Task_2
    - Factorial number with recurency and without,
    - FizzBuzz game,
    - Calculate an angle between hands of a clock
- Task_3
    
    Check if a given number contains digit 3. Rules: Cannot convert number to other type and cannot use built-in functions like Contains, StartsWith etc,
- Task_4

    Create a method that validates date between years: 2001-2099. Rules: Cannot use built-in functions like Calendar etc. Method accepts three parameters: day, month and year. Returns boolean value that states if date is valid or not. Only dates between 2001 and 2099 are going to be validated. 
- Task_5
    Create a program that reads a set of instructions from a file, executes them one by one and prints the result. Example file:
    ```
    add 2
    multiply 3
    apply 10
    ```
    How it works? We take a value from the apply instruction. Its gonna be our start number then we execute the instructions from the top to the bottom.
    ```
    10
    10 + 2
    (10 + 2) * 3
    36 <-- final result
    ```
 - Task_6
    Write a program that draws Christmass tree in the console. Tree consist of two parts. Main top vertex and optional tree trunk. 
    ```
       *
      ***
     *****
       |
       |
    ```
 - Task_7
    Write a program that returns the first lower number then the one provided as a parameter. Method should accept and return long data type. When no smaller number is to be found return -1 value. Example
    ```
    123 => -1
    213 => 132
    ```
 - Task_8
    Nokia 3310 :phone: Classic mobile phone with classic keyboard and an old style text input. Convert provided text to the key sequence required to push in order to get our text. Key numbers and its letters are shown below. For the simplicity only letters form A to Z are allowed. No special characters except one - space. Space is generated by pressing # symbol once.
```
-------------------------
|       |  ABC  |  DEF  |
|   1   |   2   |   3   |
-------------------------
|  GHI  |  JKL  |  MNO  |
|   4   |   5   |   6   |
-------------------------
| PQRS  |  TUV  | WXYZ  |
|   7   |   8   |   9   |
-------------------------
|       |       |       |
|   *   |   0   |   #   |
-------------------------
```
Examples:</br>
"CAT" => 22228 (three times pressed 2 to get C, then 2 pressed once to get A and 8 pressed once to get T)</br>
"HELLO THERE" => 4433555555666#8443377733

- Task_9
    Program that calculates the result from the mathematical operations provided as a string. Only following operators are allowed: [+,-,*,/,^]. Example:
```
"1+2" => 3
"1+(2+3)*2" => 11
```

- Task_10
    Write a program that converts Roman numeral string to arabic number and the other way round from arabic to roman. Example:
```
"X" => 10,
"XXIX" => 29
 1 => "I"
 999 => "CMXCIX"
```
