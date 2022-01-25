import React, { useState } from "react";
import "./PackageSearch.css";
import { AppConfiguration } from "read-appsettings-json";

export default function PackageSearch({ token }) {
  const logOut = () => {
    sessionStorage.removeItem("token");
    window.location.reload(true);
  };

  const [packageId, setPackageId] = useState();
  const [version, setVersion] = useState();
  const [apiResult, setApiResult] = useState("");

  async function loginUser(parameters) {
    return fetch(
      AppConfiguration.Setting().apiendpoint +
        "Updates/GetAvailableUpdates" +
        "?packageid=" +
        parameters.packageId +
        "&version=" +
        parameters.version,
      {
        method: "GET",
        headers: {
          "Content-Type": "application/json",
          Authorization: "Bearer " + token,
        },
      }
    ).then((data) => data.json());
  }

  const handleSubmit = async (e) => {
    e.preventDefault();

    const result = await loginUser({
      packageId,
      version,
    });
    console.log(result);
    setApiResult(result);
  };

  return (
    <div>
      <label className="logoutLblPos">
        <input
          className="btn"
          align="left"
          name="logOut"
          type="button"
          value="Log out"
          onClick={logOut}
        />
      </label>
      <div className="packagesearch-wrapper">
        <form onSubmit={handleSubmit}>
          <label>
            <p>Package Id</p>
            <input type="text" onChange={(e) => setPackageId(e.target.value)} />
          </label>
          <label>
            <p>Version</p>
            <input type="text" onChange={(e) => setVersion(e.target.value)} />
          </label>
          <div>
            <button type="submit">Submit</button>
          </div>
        </form>
        <label className="messageLbl">{apiResult.message}</label>
      </div>
    </div>
  );
}
