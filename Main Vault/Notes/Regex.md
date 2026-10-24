
| Symbol  | Meaning                                                     |
| ------- | ----------------------------------------------------------- |
| \d      | Any number                                                  |
| \D      | Anything besides numbers                                    |
| \\.     | Periods                                                     |
| .       | Any character                                               |
| .+      | 1 or more characters                                        |
| \[abc]  | One of these characters                                     |
| \[^abc] | Exclude these characters                                    |
| \[0-5]  | Match numbers 0-5                                           |
| \[^n-p] | Exclude letters n to p                                      |
| a{3}    | 3 a's                                                       |
| a{1,3}  | 1-3 a's                                                     |
| a+      | 1 or more a's                                               |
| a*      | Any number of a's                                           |
| a?bc    | A is optional, but B and C are not                          |
| \t      | Tab                                                         |
| \T      | Anything but tab                                            |
| \n      | New Line                                                    |
| \N      | Anything but a new line                                     |
| \r      | Carriage Return                                             |
| \R      | Anything but carriage return                                |
| \s      | Whitespace / tab / new line / return                        |
| \S      | Anything but whitespace                                     |
| \^a     | Only if it starts with a                                    |
| a$      | Only if it ends with a                                      |
| ()      | Doesn't change what's matched<br>changes what's remembered. |
| a\|b    | A or B                                                      |
| \w      | Alphanumeric letters and digits                             |
| \W      | Anything but an alphanumeric letter/digit                   |
| \b      | Word boundary                                               |
