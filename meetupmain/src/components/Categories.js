import React from "react";
import "../assets/styles/Categories.css";
import { Link } from "react-router-dom";

const Categories = () => {
  return (
    <div className="categories">
      <div className="col">
        <div className="row">
          <img src="" alt="" />
          <button>
            <Link className="link" to="/events">
              All
            </Link>
          </button>
        </div>
        <div className="row">
          <img src="" alt="" />
          <button>
            <Link to="/events/2" className="link">
              Travel
            </Link>
          </button>
        </div>
      </div>
      <div className="col">
        <div className="row">
          {" "}
          <img src="" alt="" />
          <button>
            <Link to="/events/2" className="link">
              Art
            </Link>
          </button>
        </div>
      </div>
      <div className="col col-l">
        <div className="row">
          <div className="col">
            <div className="row">
              <img src="" alt="" />
              <button>
                <Link to="/events/3" className="link">
                  Tech
                </Link>
              </button>
            </div>
          </div>
          <div className="col">
            <div className="row">
              {" "}
              <img src="" alt="" />
              <button>
                <Link to="/events/4" className="link">
                  Culture
                </Link>
              </button>
            </div>
          </div>
        </div>
        <div className="row">
          <img src="" alt="" />
          <button>
            <Link to="/products/1" className="link">
              some category
            </Link>
          </button>
        </div>
      </div>
    </div>
  );
};

export default Categories;
