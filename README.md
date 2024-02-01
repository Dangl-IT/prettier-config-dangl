Installation
Install as a dev dependency (along with prettier) via npm:


npm install --save-dev @swimlane/prettier-config-swimlane prettier@latest @trivago/prettier-plugin-sort-imports@latest
 
Usage
Create a file named prettier.config.js with the following contents:


'use strict';module.exports = require('@dangl/prettier-config-dangl');
 
Add a prettier script to package.json:


{
  "scripts": {
    "prettier": "prettier --write \"**/*.js\""
  }
}
 
Adjust the glob pattern as needed to include more file extensions. For example, \"**/*.{js,ts}\" will format both JavaScript and TypeScript files and etc. Files can be excluded with a .prettierignore file.
Executing npm run prettier will now format a project's files.
