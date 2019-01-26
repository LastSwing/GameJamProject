const fs = require('fs-extra');
const Fs = require('fs');
const path = require('path');
const gulp = require('gulp');
const globby = require('globby');
const del = require('del');

const deat = '../GameJamProject/Assets/Resources/Json/Merge/';
const mergeFiles = {
    stuff: 'Stuffs.json',
    prop: 'Props.json',
    father: 'FatherOptions.json'
};

/**
 * stuff prop
 * @param Id {int}
 * @param KeyName {string}
 * @param ItemId {int}
 * @param ItemName {string}
 * @param ItemModel ｛string｝
 * @param ItemSchedule {string}
 * @param ItemExplain {string}
 * @param TalkList {textObj []}
 * @param OptionsList ｛optionObj []｝
 */

gulp.task('stuff', function (done) {
    let stuffs = fs.readJsonSync('Json/ItemList.json');

    stuffs.forEach(element => {
        let stuffContextName = element.TalkList;
        let stuffOptionName = element.OptionList;

        let talkList, optionsList;
        // load TalkList
        let contextfiles = globby.sync('./Json/TalkTextList/*');
        contextfiles.forEach(obj => {
            let pathObj = path.parse(obj);
            let name = pathObj.name;
            // lost data
            if (!name) {
                console.log("TalkList obj lost Data.");
            }

            if (name === stuffContextName) {
                talkList = fs.readJsonSync(obj);
            }
        });

        // load options
        let optionfiles = globby.sync('./Json/OptionsTextList/*');
        optionfiles.forEach(obj => {
            let pathObj = path.parse(obj);
            let name = pathObj.name;
            // options lost data
            if (!name) {
                console.log("OptionList obj lost Data.");
            }

            if (name === stuffOptionName) {
                optionsList = fs.readJsonSync(obj);
            }
        });
        if (talkList)  element.TalkList = talkList;
        else console.log("talkList lost");
        if (optionsList) element.OptionList = optionsList;
        else console.log('optionsList lost');

    });
    // create the result
    let res = dest + mergeFiles.stuff;
    if (Fs.existsSync(res)) {
        del.sync(res, {force: true});
    }
    else {
        Fs.mkdirSync(path.parse(res).dir);
    }
    fs.writeJsonSync(res, stuffs);

});

gulp.task('prop', function () {
    
});

gulp.task ('father', function () {

});