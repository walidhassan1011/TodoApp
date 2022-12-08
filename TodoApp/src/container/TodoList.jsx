import React, { useEffect, useState } from "react";
import { useDrop } from "react-dnd";
import { NavBar, SliderMenu, TodoCard, TodoWrapper } from "../components";
import Wrapper from "../Wrapper";
import style from "./Todo.module.css";
import * as GrIcons from "react-icons/gr";
import * as CiIcons from "react-icons/ci";
import * as MdIcons from "react-icons/md";
import { statuses } from "../constants/data";
import axios from "axios";

const TodoList = () => {
  const [todos, setTodos] = useState([]);

  useEffect(() => {
    axios.get("https://localhost:7109/api/TodoItems").then((res) => {
      setTodos(res.data);
    });
  }, []);
  const handleDelete = (e, id) => {
    axios
      .delete(`https://localhost:7109/api/TodoItems/${id}`)
      .then((res) => {
        console.log(res);
      })
      .catch((err) => {
        console.log(err);
      });
    window.location.reload();
  };

  const onDrop = (item, monitor, status) => {
    setTodos((prev) => {
      const newTodos = [...prev]
        .filter((i) => i.id !== item.id)
        .concat({ ...item, status });
      return [...newTodos];
    });

    axios
      .put(`https://localhost:7109/api/TodoItems/${item.id}`, {
        title: item.title,
        description: item.description,
        status: status,
      })
      .then((res) => {
        console.log(res);
      });
  };

  const moveItem = (dragIndex, hoverIndex) => {
    const item = todos[dragIndex];
    setTodos((prev) => {
      const newTodos = [...prev].filter((i, idx) => idx !== dragIndex);
      newTodos.splice(hoverIndex, 0, item);
      return [...newTodos];
    });
  };

  return (
    <>
      <section
        style={{
          display: "flex",
          borderRadius: "20px",
          minHeight: "100vh",
          maxWidth: "1400px",

          flex: 1,
          backgroundColor: "#fff",
        }}
      >
        <div className={style.Sider_Menu}>
          <SliderMenu />
          <div className={`${style.Slider_bottom} ${style.Slider_Body}`}>
            <ul>
              <li>
                <span>
                  <CiIcons.CiSettings />
                </span>
                Settings
              </li>
              <li>
                <span>
                  <MdIcons.MdLogout />
                </span>
                Logout
              </li>
            </ul>
          </div>
        </div>
        <br
          style={{
            width: "3px",
            height: "100%",
            backgroundColor: "#e0e0e0",
          }}
        />
        <div className={style.Main_right}>
          <div className={style.NavBar}>
            <NavBar />
          </div>
          <div className={style.Main_right_middle}>
            <h1>Projects</h1>
            <button className={style.Main_right_middle_button}>
              This week
              <GrIcons.GrFormDown />
            </button>
          </div>
          <div className={style.Main_Content}>
            {statuses?.map((status) => (
              <TodoWrapper
                key={status.status}
                status={status.status}
                onDrop={onDrop}
              >
                {todos
                  ?.filter((i) => i.status === status.status)
                  .map((i, idx) => (
                    <TodoCard
                      key={i.id}
                      handleDelete={handleDelete}
                      item={i}
                      index={idx}
                      status={status}
                      moveItem={moveItem}
                    />
                  ))}
              </TodoWrapper>
            ))}
          </div>
        </div>
      </section>
    </>
  );
};

export default Wrapper(TodoList);
