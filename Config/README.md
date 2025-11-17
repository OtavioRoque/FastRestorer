# Connection String Configuration

This folder contains the connection string configuration files used by the project.

## 🧩 `App.config`

- Versioned in the repository.
- Contains a fictitious connection string, used only as a reference model.

## 🔒 `App.Local.config`

- Not versioned (it is in `.gitignore`).
- Must contain your real connection string for accessing SQL Server.
- To create it:
  - Make a copy of `App.config`.
  - Rename the copy to `App.Local.config`.
  - Edit the `connectionString` attribute value with your real data.
