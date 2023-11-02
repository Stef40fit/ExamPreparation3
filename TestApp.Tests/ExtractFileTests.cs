using NUnit.Framework;
using System;

namespace TestApp.Tests;

public class ExtractFileTests
{
    [Test]
    public void Test_GetFile_NullPath_ThrowsArgumentNullException()
    {
        // Arrange
        string[]? input = null;
        string[]? path = null;

        // Act + Assert
        Assert.That(() => ExtractFile.GetFile(null), Throws.ArgumentNullException);
    }

    [Test]
    public void Test_GetFile_EmptyPath_ThrowsArgumentNullException()
    {
        // Arrange
        string emptyPath = "";

        // Act and Assert
        Assert.Throws<ArgumentNullException>(() => ExtractFile.GetFile(emptyPath));
    }

    [Test]
    public void Test_GetFile_ValidPath_ReturnsFileNameAndExtension()
    {
        // Arrange
        string validPath = @"C:\Example\myfile.txt";

        // Act
        string result = ExtractFile.GetFile(validPath);

        // Assert
        Assert.AreEqual("File name: myfile\nFile extension: txt", result);
    }

    [Test]
    public void Test_GetFile_PathWithNoExtension_ReturnsFileNameOnly()
    {
        // Arrange
        string validPath = @"C:\Example\myfile";

        // Act
        string result = ExtractFile.GetFile(validPath);

        // Assert
        Assert.AreEqual("File name: myfile", result);
    }

    [Test]
    public void Test_GetFile_PathWithSpecialCharacters_ReturnsFileNameAndExtension()
    {

        // Arrange
        string validPath = @"C:\#%$@myfile.txt";

        // Act
        string result = ExtractFile.GetFile(validPath);

        // Assert
        Assert.AreEqual("File name: #%$@myfile\nFile extension: txt", result);
    }
}
