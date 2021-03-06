/**
 * @license Copyright (c) 2003-2015, CKSource - Frederico Knabben. All rights reserved.
 * For licensing, see LICENSE.md or http://ckeditor.com/license
 */

CKEDITOR.editorConfig = function( config ) {
	// Define changes to default configuration here. For example:
	// config.language = 'fr';
    // config.uiColor = '#AADC6E';
    config.fullPage = true;
    ////config.toolbarGroups = [
    ////     { name: 'document', groups: ['document', 'mode', 'source'] },
    ////     { name: 'clipboard', groups: ['clipboard', 'undo'] },
    ////     { name: 'editing', groups: ['find', 'selection', 'spellchecker', 'editing'] },
    ////     { name: 'forms', groups: ['forms'] },
    ////     { name: 'basicstyles', groups: ['basicstyles', 'cleanup'] },
    ////     '/',
    ////     { name: 'paragraph', groups: ['list', 'indent', 'blocks', 'align', 'bidi', 'paragraph'] },
    ////     { name: 'links', groups: ['links'] },
    ////     { name: 'insert', groups: ['insert'] },
    ////     '/',
    ////     { name: 'styles', groups: ['styles'] },
    ////     { name: 'colors', groups: ['colors'] },
    ////     { name: 'tools', groups: ['tools'] },
    ////     { name: 'others', groups: ['others'] },
    ////     { name: 'about', groups: ['about'] }
    ////];

    config.removeButtons = 'ShowBlocks,Form,Checkbox,Radio,TextField,Textarea,Button,ImageButton,HiddenField,Select,About,Save,NewPage,Preview,Print,Templates';
    //config.extraPlugins = 'sourcedialog';
    config.enterMode = CKEDITOR.ENTER_BR;
};
