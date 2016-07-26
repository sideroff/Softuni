<?php

require_once('config.php');
require_once('functions.php');
alert('here');
session_start();
$requestParsed = parseRequest();
processRequest($requestParsed);
