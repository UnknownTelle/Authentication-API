<?php

    $file = file_get_contents($fileName = 'CrimeData.csv');
    $openFile = fopen($fileName, 'r');
    $offence = array();
    $total = array();

    while (($data = fgetcsv($openFile,0,',')) !== FALSE);
    $CrimeData = array_map("str_getcsv", explode("\n", $file));
    $row = array_shift($CrimeData);

    foreach ($row as $item){
        $offence[] = $item;
    }
    $count = count($CrimeData) - 1;
    for($i = 0; $i < $count; $i++){
        $data = array_combine($offence, $CrimeData[$i]);
        $total[$i] = $data;
    }
    echo json_encode($total);
    exit();
?>
