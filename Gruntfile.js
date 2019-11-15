/*global module:false*/

const _ = require('lodash');
const fs = require('fs');
const rimraf = require("rimraf");

module.exports = function (grunt) {
  require('load-grunt-tasks')(grunt);

  const SWAGGER_VERSION = "3.0.4";
  const SWAGGER_JAR = `swagger-codegen-cli-${SWAGGER_VERSION}.jar`;
  const SWAGGER_URL = `https://search.maven.org/remotecontent?filepath=io/swagger/codegen/v3/swagger-codegen-cli/${SWAGGER_VERSION}/${SWAGGER_JAR}`;
  const TYPESCRIPT_MODEL_PACKAGE = "test-client";
  const TYPESCRIPT_MODEL_VERSION = "2.0";

  grunt.registerMultiTask('typescript-spec-post-process', 'Post process', function () {
    const rootFolder = "./typescript-client-generated";
    const apiFolder = `${rootFolder}/api`;
    const modelFolder = `${rootFolder}/model`;

    if (fs.existsSync(apiFolder)) {
      rimraf.sync(apiFolder);
    }

    if (fs.existsSync(modelFolder)) {
      rimraf.sync(modelFolder);
    }

    if (fs.existsSync(`${rootFolder}/index.ts`)) {
      fs.unlinkSync(`${rootFolder}/index.ts`);
    }

    fs.renameSync(`${this.data.folder}/api/api.ts`, `${rootFolder}/index.ts`);
    fs.renameSync(`${this.data.folder}/api`, apiFolder);
    fs.renameSync(`${this.data.folder}/model`, modelFolder);

  });

  grunt.initConfig({
    "curl": {
      "swagger-codegen": {
        src: SWAGGER_URL,
        dest: SWAGGER_JAR
      }
    },
    "clean": {
      "typescript-client": [
        "typescript-client-generated/typings.json",
        "typescript-client-generated/api.module.ts",
        "typescript-client-generated/variables.ts",
        "typescript-client-generated/encoder.ts",
        "typescript-client-generated/configuration.ts"
      ], 
      "csharp-client": {
        src: [
          "unity-csharp-client-generated/docs",
          "unity-csharp-client-generated/src/IO.Swagger.Test",
          "unity-csharp-client-generated/src/IO.Swagger/Client"
        ]
      }
    },
    "shell": {
      "typescript-spec-generate": {
        command: `java -jar ${SWAGGER_JAR} generate ` +
          "-i ./swagger.yaml " +
          "-l typescript-angular " +
          "-t typescript-spec-template/ " +
          "-o typescript-spec-generated/ " +
          "--template-engine mustache " +
          "--type-mappings Date=string "
      },
      "typescript-client-generate": {
        command: `java -jar ${SWAGGER_JAR} generate ` +
          "-i ./swagger.yaml " +
          "-l typescript-angular " +
          "-t typescript-client-template/ " +
          "-o typescript-client-generated/ " +
          "--template-engine mustache " +
          `--additional-properties projectName=${TYPESCRIPT_MODEL_PACKAGE},npmName=${TYPESCRIPT_MODEL_PACKAGE},npmVersion=${TYPESCRIPT_MODEL_VERSION}`
      },
      "unity-typescript-client-generate": {
        command: `java -jar ${SWAGGER_JAR} generate ` +
          "-i ./swagger.yaml " +
          "-l csharp " +
          "-t unity-client-template/ " +
          "-o unity-client-generated/ " +
          "--template-engine handlebars " +
          "--type-mappings Date=string "
      },
      "unity-csharp-client-generate": {
        command: `java -jar ${SWAGGER_JAR} generate ` +
          "-i ./swagger.yaml " +
          "-l csharp " +
          "-t unity-csharp-client-template/ " +
          "-o unity-csharp-client-generated/ " +
          "--template-engine handlebars " +
          "--type-mappings int64=int,Boolean=boolean,Float=float,  "
      }/* ,
      'typescript-client-bump-version': {
        command: 'npm version patch',
        options: {
          execOptions: {
            cwd: 'typescript-client-generated'
          }
        }
      },
      'typescript-client-push': {
        command : 'git add . && git commit -m "Generated javascript source" && git push',
        options: {
          execOptions: {
            cwd: 'typescript-client-generated'
          }
        }
      },
      "typescript-client-publish": {
        command : 'npm install && npm run build && npm publish',
        options: {
          execOptions: {
            cwd: 'typescript-client-generated'
          }
        }
      } */,
    },
    "typescript-spec-post-process": {
      "api": {
        "folder": "typescript-spec-generated"
      }
    }
  });

  grunt.registerTask('download-dependencies', 'if-missing:curl:swagger-codegen');
  grunt.registerTask('typescript-spec', ["download-dependencies", "shell:typescript-spec-generate", "typescript-spec-post-process:api"]);
  grunt.registerTask('typescript-client-gen', ['shell:typescript-client-generate', 'clean:typescript-client']);
  //grunt.registerTask('typescript-client', [ 'typescript-client-gen', "shell:typescript-client-bump-version", "shell:typescript-client-push", "shell:typescript-client-publish" ]);
  grunt.registerTask('typescript-api-gen', ['shell:typescript-client-generate', 'typescript-spec-post-process:api'])
  grunt.registerTask('unity-csharp-client-gen', ['shell:unity-csharp-client-generate', 'clean:csharp-client']);

};