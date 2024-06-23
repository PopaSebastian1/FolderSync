# Folder Synchronization Program

This C# program synchronizes the content of a source folder to a destination (replica) folder. It periodically checks for changes in the source folder and updates the destination folder accordingly. Here's how to use and understand the program:

---

## Program Requirements

1. **One-way Synchronization**: Copies all files and directories from the source folder to the destination folder, ensuring they are identical.
2. **Periodic Synchronization**: Syncs at regular intervals specified in seconds via command line arguments.
3. **Logging**: Logs all file operations (creation, copying, removal) to both a specified log file and console output.

---

## Implementation Details

### Folder Class

- **Path**: Holds the path of the folder.

### FolderSync Class

- **SourceFolder, DestinationFolder**: Instances of the `Folder` class representing source and destination folders.
- **SyncInterval**: Interval (in milliseconds) between synchronization operations.
- **LogFile**: Path to the log file where synchronization operations are logged.
- **LastSyncTime**: Tracks the last synchronization time.
- **Sync()**: Initiates the synchronization process by calling `SyncFolder()`.
- **SyncFolder(string sourcePath, string destinationPath)**: Recursively synchronizes files and directories between source and destination folders, using parallel processing for efficient handling.
- **Log(string message)**: Logs messages to the specified log file using a thread-safe approach.

### Program Class

- **Main(string[] args)**: Parses command line arguments, initializes the `FolderSync` instance, and schedules periodic synchronization using a `Timer`.
- **SyncCallback(object state)**: Callback method executed by the `Timer` to trigger synchronization and print completion messages to the console.

---

## Usage

1. **Compile**: Compile the program using C# compiler (e.g., `dotnet build`).
2. **Run**: Execute the compiled program with the following command line arguments:
   - `sourcePath`: Path to the source folder.
   - `destinationPath`: Path to the destination (replica) folder.
   - `intervalInSeconds`: Interval in seconds between sync operations.
   - `logFilePath`: Path to the log file where synchronization operations are logged.

## How It Works

The program operates in the following steps:

1. **Initialization**:
   - Reads command line arguments (`sourcePath`, `destinationPath`, `intervalInSeconds`, `logFilePath`).
   - Initializes instances of `FolderSync` and sets up necessary directories and files (if they do not exist).

2. **Synchronization Process**:
   - **SyncCallback**: Executed at regular intervals (specified by `intervalInSeconds`), triggers the synchronization process.
   - **SyncFolder**: Recursively compares files and directories between `SourceFolder` and `DestinationFolder`.
     - Deletes files and directories from `DestinationFolder` that do not exist in `SourceFolder`.
     - Copies new or modified files from `SourceFolder` to `DestinationFolder`.
     - Deletes directories from `DestinationFolder` that do not exist in `SourceFolder`.
     - Continues recursively for all subdirectories.

3. **Logging**:
   - Logs each operation (file deletion, file synchronization, directory deletion) to the specified `logFilePath` and displays messages on the console.
   - Uses a thread-safe approach (`logLock`) to ensure multiple threads can log simultaneously without conflicts.

4. **Completion**:
   - Outputs synchronization completion messages to the console after each synchronization cycle.

---
