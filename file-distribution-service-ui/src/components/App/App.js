import React from "react";
import { BrowserRouter, Route, Switch } from "react-router-dom";
import "./App.css";
import PackageSearch from "../PackageSearch/PackageSearch";
import Login from "../Login/Login";
import useToken from "./useToken";

function App() {
  const { token, setToken } = useToken();
  if (!token) {
    return <Login setToken={setToken} />;
  }
  return (
    <div className="wrapper">
      <h1>Application</h1>
      <BrowserRouter>
        <Switch>
          <Route path="/">
            <PackageSearch token={token} />
          </Route>
        </Switch>
      </BrowserRouter>
    </div>
  );
}

export default App;
