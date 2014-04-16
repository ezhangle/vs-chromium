﻿using System.Collections.Generic;
using System.Linq;
using VsChromium.Core.Ipc.TypedMessages;
using VsChromium.Server.FileSystemNames;

namespace VsChromium.Server.FileSystem.Snapshot {
  public static class FileSystemSnapshotExtensions {
    public static  FileSystemTree ToIpcFileSystemTree(this FileSystemSnapshot tree) {
      return new FileSystemTree {
        Version = tree.Version,
        Root = BuildFileSystemTreeRoot(tree)
      };
    }

    private static DirectoryEntry BuildFileSystemTreeRoot(FileSystemSnapshot fileSystemSnapshot) {
      return new DirectoryEntry {
        Name = null,
        Data = null,
        Entries = fileSystemSnapshot.ProjectRoots.Select(x => BuildDirectoryEntry(x)).Cast<FileSystemEntry>().ToList()
      };
    }

    private static DirectoryEntry BuildDirectoryEntry(DirectorySnapshot directoryEntry) {
      return new DirectoryEntry {
        Name = directoryEntry.DirectoryName.Name,
        Data = null,
        Entries = BuildEntries(directoryEntry)
      };
    }

    private static FileSystemEntry BuildFileEntry(FileName filename) {
      return new FileEntry {
        Name = filename.Name,
        Data = null
      };
    }
    private static List<FileSystemEntry> BuildEntries(DirectorySnapshot directoryEntry) {
      return directoryEntry.DirectoryEntries
        .Select(x => BuildDirectoryEntry(x))
        .Concat(directoryEntry.Files.Select(x => BuildFileEntry(x)))
        .ToList();
    }

  }
}