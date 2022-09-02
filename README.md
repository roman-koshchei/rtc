# Real Time Copy

Service can track changes in file and update copy on saving.

## Types

1. Full directory = track all files in directory and subdirectories
2. One file
3. Several files in one directory


### 1. Full directory

Set input directory as incomming path. Output directory is directory above coping directory

```
|- real
  |- dir
      |- file.txt
      |- subdir
|- copy
  |- dir
      |- file.txt
      |- subdir
```

Input is "./real/dir". Output is "./copy"


## 2. One file

```
|- real
  |- dir
      |- file.txt
      |- subdir
|- copy
  |- file.txt
```

Input is "./real/dir/file.txt". Output is "./copy"


## 2. Several files in one directory

```
|- real
  |- dir
      |- file.txt
      |- s.txt
|- copy
  |- file.txt
  |- s.txt
```

Input is ["./real/dir/file.txt", "./real/dir/s.txt"]. Output is "./copy"
