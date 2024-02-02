
# prettier-config-dangl

[Prettier](https://prettier.io/) configuration used in [**Dangl IT GmbH**](https://www.dangl-it.com/) projects.


## Installation

Install as a dev dependency (along with [Prettier](https://prettier.io/)) via [npm](https://www.npmjs.com/):



```bash
npm install --save-dev @dangl/prettier-config-dangl prettier@latest @trivago/prettier-plugin-sort-imports
```
    
## Usage
1. Create a file named `prettier.config.js` with the following contents:
```javascript
'use strict';

module.exports = require("@dangl/prettier-config-dangl");
```

2. Add a [Prettier](https://prettier.io/) script to `package.json`: 
```json
{
  "scripts": {
    "prettier": "prettier --write \"**/*.js\""
  }
}
```
> Adjust the glob pattern as needed to include more file extensions. For example, \"**/*.{js,ts}\" will format both JavaScript and TypeScript files. Files can be excluded with a .prettierignore file.
