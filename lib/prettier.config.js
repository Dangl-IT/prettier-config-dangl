'use strict';

const prettierConfig = {
   overrides: [
     {
       files: ['*.ts', '*spec.ts'],
       options: {
         singleQuote: true,
         trailingComma: 'none',
         printWidth: 140,
         endOfLine: 'auto',
         importOrder: [
           '^@angular/',
           '^@dangl/*',
           '^rxjs/*',
           '<THIRD_PARTY_MODULES>',
           '^app/',
           '^\\.\\.\\/\\.\\.\\/.*',
           '^\\.\\/.*',
           '.*',
         ],
         importOrderSeparation: true,
         parser: 'typescript',
         importOrderParserPlugins: ['typescript', 'decorators-legacy'],
         plugins: ['@trivago/prettier-plugin-sort-imports'],
       },
     },
     {
       files: ['*.html'],
       options: {
         singleQuote: true,
         tabWidth: 2,
         printWidth: 140,
         endOfLine: 'auto',
       },
     },
   ],
 };
 
 module.exports = prettierConfig;