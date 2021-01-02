# WPCracker

WordPress user enumeration and login Brute Force tool

The tool makes it possible to adjust the number of threads as well as how large password batches each thread is tested at a time.

It takes about two days to go through the rockyou.txt (14,341,564 unique passwords) dictionary on my hardware when using the program's presets for the number of threads (12) and the size of the batches (1000).

# Using:

## User Enumeration
```Bash
.\WPCracker.exe --enum -u <Url to victim's wp-login.php>
```
#### OR JUST
```Bash
.\WPCracker.exe --enum
```
In this case, the program only requests the required information

## Brute Force

### Using program's presets
```Bash
.\WPCracker.exe --brute -u <Url to victim's WordPress page> -p <Path to wordlist> -n <Username>
```
#### OR JUST
```Bash
.\WPCracker.exe --brute
```
In this case, the program only requests the required information

### Using with custom settings
```Bash
.\WPCracker.exe --brute -u <Url to victim's WordPress page> -p <Path to wordlist> -n <Username> -t <Max threads> -c <Batch maximum size>
```

### Get help
```Bash
.\WPCracker.exe --brute -?
```

# This is for ethical use only :)

#### Thank's for [adamabdelhamed's PowerArgs](https://github.com/adamabdelhamed/PowerArgs "PowerArgs")
