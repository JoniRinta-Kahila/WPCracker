# Modern Microsoft login page for pentesting.

###### Good looking html login and a bit of JavaScript ensures user information collection.

###### __Please note!__ Currently, passwords are only stored in the session storage and are not currently stored in the file. However, it is possible to ask for usernames and passwords by retrieving them from the session storage.

for example;

```javascript
let userName = sessionStorage.getItem("user");
let password = sessionStorage.getItem("password");
```

#
###### ToDo; Mobile version
#

This is for ethical use only :)