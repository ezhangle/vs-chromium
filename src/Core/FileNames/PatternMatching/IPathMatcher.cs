// Copyright 2013 The Chromium Authors. All rights reserved.
// Use of this source code is governed by a BSD-style license that can be
// found in the LICENSE file.

namespace VsChromium.Core.FileNames.PatternMatching {
  public interface IPathMatcher {
    bool MatchDirectoryName(RelativePathName path, IPathComparer comparer);
    bool MatchFileName(RelativePathName path, IPathComparer comparer);
  }
}