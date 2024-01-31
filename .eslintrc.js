module.exports = {
   parser: '@typescript-eslint/parser',
   plugins: [
     '@typescript-eslint',
     'angular',
     'prettier'
   ],
   extends: [
     'plugin:@typescript-eslint/recommended',
     'plugin:angular/recommended',
     'prettier',
     'prettier/@typescript-eslint',
     'prettier/angular'
   ],
   rules: {
     'prettier/prettier': 'error'
   }
 };