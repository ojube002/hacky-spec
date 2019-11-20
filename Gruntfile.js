/*global module:false*/

const _ = require('lodash');
const fs = require('fs');
const rimraf = require("rimraf");

module.exports = function (grunt) {
  require('load-grunt-tasks')(grunt);

  const SWAGGER_VERSION = "3.0.4";
  const SWAGGER_JAR = `swagger-codegen-cli-${SWAGGER_VERSION}.jar`;
  const SWAGGER_URL = `https://search.maven.org/remotecontent?filepath=io/swagger/codegen/v3/swagger-codegen-cli/${SWAGGER_VERSION}/${SWAGGER_JAR}`;

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
      "typescript-spec": {
        src: [
          "typescript-client-generated/.swagger-codegen",
          "typescript-client-generated/.gitignore",
          "typescript-client-generated/.swagger-codegen-ignore",
          "typescript-client-generated/git_push.sh",
          "typescript-client-generated/package.json",
          "typescript-client-generated/README.md",
          "typescript-client-generated/tsconfig.json",
          "typescript-client-generated/api.module.ts",
          "typescript-client-generated/configuration.ts",
          "typescript-client-generated/encoder.ts",
          "typescript-client-generated/variables.ts",
          "typescript-client-generated/api/user.service.ts",
          "typescript-spec-generated"
        ]
      },
      "csharp-client": {
        src: [
          "unity-csharp-client-generated/docs",
          "unity-csharp-client-generated/src/IO.Swagger.Test",
          "unity-csharp-client-generated/src/IO.Swagger/Client"
        ]
      }
    },
    "shell": {
      "server-generate": {
        command: `java -jar ${SWAGGER_JAR} generate ` +
          "-i ./swagger.yaml " +
          "-l typescript-angular " +
          "-t typescript-spec-template/ " +
          "-o typescript-spec-generated/ " +
          "--template-engine mustache " +
          "--type-mappings Date=string "
      },
      "unity-generate": {
        command: `java -jar ${SWAGGER_JAR} generate ` +
          "-i ./swagger.yaml " +
          "-l csharp " +
          "-t unity-csharp-client-template/ " +
          "-o unity-csharp-client-generated/ " +
          "--template-engine handlebars " +
          "--type-mappings Integer=int,Boolean=bool,Float=float,  "
      }/* 
      'typescript-client-push': {
        command : 'git add . && git commit -m "Generated javascript source" && git push',
        options: {
          execOptions: {
            cwd: 'typescript-client-generated'
          }
        }
      }*/,
    },
    "typescript-spec-post-process": {
      "api": {
        "folder": "typescript-spec-generated"
      }
    }
  });

  grunt.registerTask('download-dependencies', 'if-missing:curl:swagger-codegen');
  grunt.registerTask('server-generate', ["download-dependencies", "shell:server-generate", "typescript-spec-post-process:api", "clean:typescript-spec"]);
  grunt.registerTask('unity-generate', ['shell:unity-generate', 'clean:csharp-client']);

};