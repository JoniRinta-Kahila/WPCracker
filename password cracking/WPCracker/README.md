# WPCracker

WordPress login Brute Force tool

When you test with this tool, you need to know The username. So far, username enumeration is not possible with this tool.

The tool makes it possible to adjust the number of threads as well as how large password batches each thread is tested at a time.

It takes about two days to go through the rockyou.txt (14,341,564 unique passwords) dictionary on my hardware when using the program's presets for the number of threads (12) and the size of the batches (1000).

## How to use:

### Using program's presets
```Bach
.\WPCracker.exe -u <Url to victim's wp-login.php> -p <Path to wordlist> -n <Username>
```
#### OR JUST
```Bach
.\WPCracker.exe
```
In this case, the program only requests the required information

### Using with custom settings
```Bach
.\WPCracker.exe -u <Url to victim's wp-login.php> -p <Path to wordlist> -n <Username> -t <Max threads> -c <Batch maximum size>
```

### List of arguments
```Bach
.\WPCracker.exe -?
```

# This is for ethical use only :)

#### Thank's for [adamabdelhamed's PowerArgs](https://github.com/adamabdelhamed/PowerArgs "PowerArgs")
