const fs = require('fs-extra');
const Fs = require('fs');
const path = require('path');
const gulp = require('gulp');
const globby = require('globby');

gulp.task('default', function (done) {
    let stuff = fs.readJsonSync('Main/stuff.json');

    stuff.forEach(element => {
        let stuffContextName = element.contextList;
        let stuffOptionName = element.optionsList;

        let contextList, optionsList;
        // load context
        let contextfiles = globby.sync('context/*');
        contextfiles.forEach(obj => {
            let pathObj = path.parse(obj);
            if (pathObj.name === stuffContextName) {
                contextList = fs.readJsonSync(obj);
            }
        });
        // load options
        let optionfiles = globby.sync('options/*');
        optionfiles.forEach(obj => {
            let pathObj = path.parse(obj);
            if (pathObj.name === stuffOptionName) {
                optionsList = fs.readJsonSync(obj);
            }
        });

        element.contextList = contextList;
        element.optionsList = optionsList;
    });

    fs.writeJsonSync('./Merge', stuff);
});