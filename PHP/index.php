<!DOCTYPE html>
<html lang="pt-BR">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta http-equiv="X-UA-Compatible" content="ie=edge">
    <title>Notas destinadas</title>
    <style>
      input { margin-bottom: 10px;}  
      #form { width: 50%;
              margin-left: 5%;
              margin-top: 40px; }
      #campo {width: 100%;}
      #enviar { float: right; }
      
    </style>
</head>
<body>

    <div id="form">
        <h1>Busca notas destinadas </h1>
        <form action="http://localhost/xmldestinadas/index.php" method="post">

            <label for="token" >Token:</label><br>
            <input type="text" name="token" id="campo" value="<?php if(isset($_POST['token'])) echo $_POST['token']; ?>"><br>
            <label for="login">Login:</label><br>
            <input type="text" name="login" id="campo"  value="<?php if(isset($_POST['login'])) echo $_POST['login'];?>"><br>
            <label for="senha">Senha:</label><br>
            <input type="password" name="password" id="senha" value="<?php if(isset($_POST['password'])) echo $_POST['password']; ?>"><br>
            <label for="data-ini">Data inicial:</label><br>
            <input type="date" name="data-ini" id="date" value="<?php if(isset($_POST['data-ini'])) echo $_POST['data-ini']; ?>"><br>
            <label for="data-fim">Data final:</label><br>
            <input type="date" name="data-fim" id="date" value="<?php if(isset($_POST['data-fim'])) echo $_POST['data-fim']; ?>"><br>
            <label for="MOD">Modelo:</label><br>
            <select name="mod" value="<?php if(isset($_POST['mod'])) echo $_POST['mod']; ?>">
                <option value="NFE" selected>NFE</option> 
                <option value="NFCE">NFCE</option>
                <option value="CTE">CTE</option>
                <option value="CCE">CCE</option>
                <option value="CCECTE">CCECTE</option>
                <option value="SAT">SAT</option>
                <option value="CTEOS">CTEOS</option>
            </select>
            <button type="submit" id="enviar">Consultar</button>
        </form>


<?php


if(isset($_POST['login']) && !empty($_POST['token'] && !empty($_POST['login'])))
{
    $token    = $_POST['token'];
    $data_ini = date("Y-m-d", strtotime($_POST['data-ini']));
    $data_fim = date("Y-m-d", strtotime($_POST['data-fim']));
    $mod      = $_POST['mod'];
    $auth = base64_encode($_POST['login'].':'.$_POST['password']);

    //PRIMEIRA BUSCA REALIZADA 
    $curl = curl_init();
    curl_setopt($curl, CURLOPT_SSL_VERIFYHOST, 0);
    curl_setopt($curl, CURLOPT_SSL_VERIFYPEER, 0);


    curl_setopt_array($curl, array(
    CURLOPT_URL => "https://app.notasegura.com.br/api/invoices/keys?token=".$token."&date_ini=".$data_ini."&date_end=".$data_fim."&mod=".$mod."&transaction=received&limit=30&last_id=",
    CURLOPT_RETURNTRANSFER => true,
    CURLOPT_ENCODING => "",
    CURLOPT_MAXREDIRS => 10,
    CURLOPT_TIMEOUT => 30,
    CURLOPT_HTTP_VERSION => CURL_HTTP_VERSION_1_1,
    CURLOPT_CUSTOMREQUEST => "GET",
    CURLOPT_HTTPHEADER => array(
        "Accept: */*",
        "Accept-Encoding: gzip, deflate",
        "Authorization: Basic ".$auth,
        "Cache-Control: no-cache",
        "Connection: keep-alive",
        "Host: app.notasegura.com.br",
        "Postman-Token: aa05e2e2-8dcb-4441-9ab5-777a7de1e31f,d540760b-5b53-4ff3-b062-76b002774ca1",
        "User-Agent: PostmanRuntime/7.15.2",
        "cache-control: no-cache"
    ),
    ));

    $response = json_decode(curl_exec($curl));
    $err = curl_error($curl);
    curl_close($curl);
    //FIM  REQUISIÇÃO 

    if ($err) {
        echo "cURL Error #:" . $err;
    } else {

        //ALIMENTANDO VARIAVEIS COM O RETORNO DO JSON
        if($response->error == true)
        {   
            echo $response->message;
            exit;
        }
         

        $total  = $response->data->total;
        $notas  = $response->data->invoices;
        $lastid = $response->data->last_id; 
        $count  = $response->data->count;
        //

        echo '<table><th>Chaves das notas</th>  ';
        //PERCORRENDO AS PRIMEIRAS NOTAS BUSCADAS
        foreach($notas as $n){
        echo '<tr><td><a href="http://localhost/xmldestinadas/xml.php?key='.$n->key.'&auth='.$auth.'&token='.$token.'">'.$n->key.'</a> </td></tr>';
        }

        //VERIFICA SE EXISTE MAIS NOTAS, CASO EXISTE REALIZA A BUSCA
        $total -= $count;
        while ($total > 0) {

        //BUSCAR RESTANTE DAS NOTAS
        $curl = curl_init();
        curl_setopt($curl, CURLOPT_SSL_VERIFYHOST, 0);
        curl_setopt($curl, CURLOPT_SSL_VERIFYPEER, 0);
        curl_setopt_array($curl, array(
            CURLOPT_URL => "https://app.notasegura.com.br/api/invoices/keys?token=".$token."&date_ini=".$data_ini."&date_end=".$data_fim."&mod=".$mod."&transaction=received&limit=30&last_id=".$lastid,
            CURLOPT_RETURNTRANSFER => true,
            CURLOPT_ENCODING => "",
            CURLOPT_MAXREDIRS => 10,
            CURLOPT_TIMEOUT => 30,
            CURLOPT_HTTP_VERSION => CURL_HTTP_VERSION_1_1,
            CURLOPT_CUSTOMREQUEST => "GET",
            CURLOPT_HTTPHEADER => array(
                "Accept: */*",
                "Accept-Encoding: gzip, deflate",
                "Authorization: Basic ".$auth,
                "Cache-Control: no-cache",
                "Connection: keep-alive",
                "Host: app.notasegura.com.br",
                "Postman-Token: aa05e2e2-8dcb-4441-9ab5-777a7de1e31f,d540760b-5b53-4ff3-b062-76b002774ca1",
                "User-Agent: PostmanRuntime/7.15.2",
                "cache-control: no-cache"
            ),
            ));
        $response2 = json_decode(curl_exec($curl));
        $err = curl_error($curl);
        curl_close($curl);


        if ($err) {
            echo "cURL Error #:" . $err;
            break;
        }else{

            $notas  = $response2->data->invoices;
            $count  = $response2->data->count;
            $lastid = $response2->data->last_id;

            foreach($notas as $s){
                echo '<tr><td><a href="http://localhost/xmldestinadas/xml.php?key='.$s->key.'&auth='.$auth.'&token='.$token.'">'.$s->key.'</a> </td></tr>';
            }
        }
        $total -= $count;
        
        }
        echo '</table>';
    }
}
?>
    </div>
</body>
</html>

