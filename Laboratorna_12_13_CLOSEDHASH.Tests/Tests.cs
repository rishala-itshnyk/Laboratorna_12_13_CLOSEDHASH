namespace Laboratorna_12_13_CLOSEDHASH.Tests;

public class Tests
{
    [Test]
    public void AddStudent_ValidInput_StudentAddedSuccessfully()
    {
        // Arrange
        ClosedHashTable hashTable = new ClosedHashTable();
        string surname = "Порошенко";
        int[] grades = { 85, 90, 92 };

        // Act
        hashTable.Add(surname, grades);

        // Assert
        Assert.True(hashTable.Search(surname, out int[] result));
        Assert.AreEqual(grades, result);
    }

    [Test]
    public void SearchStudent_ExistingStudent_StudentFound()
    {
        // Arrange
        ClosedHashTable hashTable = new ClosedHashTable();
        string surname = "Порошенко";
        int[] grades = { 85, 90, 92 };
        hashTable.Add(surname, grades);

        // Act
        bool found = hashTable.Search(surname, out int[] result);

        // Assert
        Assert.True(found);
        Assert.AreEqual(grades, result);
    }

    [Test]
    public void SearchStudent_NonExistingStudent_StudentNotFound()
    {
        // Arrange
        ClosedHashTable hashTable = new ClosedHashTable();
        string surname = "Порошенко";

        // Act
        bool found = hashTable.Search(surname, out int[] result);

        // Assert
        Assert.False(found);
        Assert.Null(result);
    }

    [Test]
    public void DeleteStudent_ExistingStudent_StudentDeletedSuccessfully()
    {
        // Arrange
        ClosedHashTable hashTable = new ClosedHashTable();
        string surname = "Doe";
        int[] grades = { 85, 90, 92 };
        hashTable.Add(surname, grades);

        // Act
        bool deleted = hashTable.Delete(surname);

        // Assert
        Assert.True(deleted);
        Assert.False(hashTable.Search(surname, out _));
    }

    [Test]
    public void DeleteStudent_NonExistingStudent_DeletionFails()
    {
        // Arrange
        ClosedHashTable hashTable = new ClosedHashTable();
        string surname = "Порошенко";

        // Act
        bool deleted = hashTable.Delete(surname);

        // Assert
        Assert.False(deleted);
    }
}