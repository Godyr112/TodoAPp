﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TodoApp.Models;
using MySql.Data;

namespace MyTodo.Controllers
{
    public class HomeController : Controller
    {
      
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        
       public JsonResult GetTodoCategorys()
        {
            var db = new tododbEntities();
            var CategoryList = db.todocategorys.ToList();
            return Json(CategoryList, JsonRequestBehavior.AllowGet);
       }
        [HttpPost]
        public JsonResult AddCategory(string newCategory)
        {
            var db = new tododbEntities();
            db.todocategorys.Add(new todocategorys() {CategoryName = newCategory });
            db.SaveChanges();
            var CategoryList = db.todocategorys.ToList();
            return Json(CategoryList, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult DeleteCategory(todocategorys delCategory)
        {
            var db = new tododbEntities();
            var category = db.todocategorys.Find(delCategory.CategoryId);
            db.todocategorys.Remove(category);            
            db.SaveChanges();
            var CategoryList = db.todocategorys.ToList();
            return Json(CategoryList, JsonRequestBehavior.AllowGet);
        }

     
        public JsonResult  GetTodoList()
        {
            var db = new tododbEntities();          
            var TodoList = db.todolist.ToList();
            return Json(TodoList, JsonRequestBehavior.AllowGet);
        }

        public JsonResult AddTodo(string newTodoText, string newTodoNote)
        {
            var db = new tododbEntities();
            db.todolist.Add(new todolist() { TodoText = newTodoText , TodoNote = newTodoNote, CategoryId = 1,Priority = "0", Status = "0" });
            db.SaveChanges();
            var TodoList = db.todolist.ToList();
            return Json(TodoList, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteTodo(todolist delTodo)
        {
            var db = new tododbEntities();
            var Todo = db.todolist.Find(delTodo.TodoId);
            db.todolist.Remove(Todo);
            db.SaveChanges();
            var TodoList = db.todolist.ToList();
            return Json(TodoList, JsonRequestBehavior.AllowGet);
        }

    }
}