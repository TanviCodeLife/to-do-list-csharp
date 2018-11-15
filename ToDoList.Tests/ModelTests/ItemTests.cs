using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToDoList.Models;
using System;
using System.Collections.Generic;

namespace ToDoList.Tests
{
  [TestClass]
  public class ItemTest :IDisposable
  {
    public void Dispose()
    {
      Item.ClearAll();
    }
    
    [TestMethod]
    public void ItemConstructor_CreatesInstanceOfItem_Item()
    {
      Item newItem = new Item("test");
      Assert.AreEqual(typeof(Item), newItem.GetType());
    }

    [TestMethod]
    public void GetDescription_ReturnDescription_String()
    {
      string description = "Walk the dog";
      Item newItem = new Item(description);
      string result = newItem.GetDescription();
      Assert.AreEqual(description, result);
    }

    [TestMethod]
    public void SetDescription_SetsNewDescription_String()
    {
      string description = "Walk the dog";
      Item newItem = new Item(description);

      string updatedDescription = "Do the dishes";
      newItem.SetDescription(updatedDescription);
      string result = newItem.GetDescription();

      Assert.AreEqual(updatedDescription, result);
    }

    [TestMethod]
    public void GetAll_ReturnsEmptyList_EmptyItemList()
    {
      //Arrange
      List<Item> newList = new List<Item>{ };

      //Act
      List<Item> result = Item.GetAll();
      foreach (Item thisItem in result)
      {
        Console.WriteLine("Output from empty list GetAll test: " + thisItem.GetDescription());
      }

      //Assert
      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void GetAll_ReturnAllItemsInList_ItemList()
    {
      string description1 = "Walk the dog";
      string description2 = "Do the dishes";
      Item newItem1 = new Item(description1);
      Item newItem2 = new Item(description2);
      List<Item> newList = new List<Item> {newItem1, newItem2};

      List<Item> result = Item.GetAll();
      foreach (Item thisItem in result)
      {
        Console.WriteLine("Output from second GetAll test: " + thisItem.GetDescription());
      }

      CollectionAssert.AreEqual(newList, result);
    }
  }
}
