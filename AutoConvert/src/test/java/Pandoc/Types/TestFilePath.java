package Pandoc.Types;

import org.junit.Assert;
import org.junit.Test;

public class TestFilePath {
    private static FilePath tester = new FilePath("some\\folder\\file.md", ".md");

    @Test
    public void testPathSplit() throws Exception {
        Assert.assertEquals(".md", tester.getExtension());
    }

    @Test
    public void testFileName() throws Exception {
        Assert.assertEquals("some\\folder\\file", tester.getFilenameAndPath());
    }

    @Test
    public void testFileCompletePath() throws Exception {
        Assert.assertEquals("some\\folder\\file.md", tester.provideCompletePath());
    }

    @Test
    public void testChangeType() throws Exception {
        FilePath second = new FilePath(tester);
        second.changeFileExtension(".docx");
        Assert.assertEquals(".docx", second.getExtension());
        Assert.assertEquals(".md", tester.getExtension());
    }

    @Test
    public void testNewPathToFile() throws Exception {
        FilePath modified = new FilePath(tester);
        modified.modifyFilePathRelative("some\\new\\path", "some\\folder");
        Assert.assertEquals("some\\new\\path\\file.md", modified.provideCompletePath());
        Assert.assertEquals("some\\folder\\file.md", tester.provideCompletePath());
    }
}
