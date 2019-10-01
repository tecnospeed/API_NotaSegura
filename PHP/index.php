<!DOCTYPE html>
<html lang="pt-BR">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta http-equiv="X-UA-Compatible" content="ie=edge">
    <title>Notas destinadas</title>
    <link rel="stylesheet" type="text/css" href="style.css"  />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>

    <link rel="stylesheet" type="text/css" href="https://cdn.datatables.net/w/dt/dt-1.10.18/datatables.min.css"/>
    <script type="text/javascript" src="https://cdn.datatables.net/w/dt/dt-1.10.18/datatables.min.js"></script>

    <script>
        function openTab(evt, Name) {

            var i, tabcontent, tablinks;

            tabcontent = document.getElementsByClassName("tabcontent");
            for (i = 0; i < tabcontent.length; i++) {
                tabcontent[i].style.display = "none";
            }

            tablinks = document.getElementsByClassName("tablinks");
            for (i = 0; i < tablinks.length; i++) {
                tablinks[i].className = tablinks[i].className.replace(" active", "");
            }
            
            document.getElementById(Name).style.display = "block";
            tablinks[evt].className += " active";
        }

    </script>

</head>
<body>
<div class="container-token">
    <div class="row">
        <div class="col-10">
            <label for="token">Token:</label>
        </div>
        <div class="col-90">
            <input type="text" id="token" name="token_1" onblur="preencherCampo(value, 'token')" value="<?php if(isset($_POST['token'])) echo $_POST['token']; ?>"  placeholder="Token.." />
        </div>
    </div>
    <div >
        <div class="row">
            <div class="col-10">
                <label for="login">Login:</label>
            </div>
            <div class="col-50">
                <input type="text" name="login_1" onblur="preencherCampo(value, 'login')" value="<?php if(isset($_POST['login'])) echo $_POST['login'];?>" placeholder="E-mail">
            </div>               
            <div class="col-5">
                <label for="password">Senha:</label> 
            </div>
            <div class="col-30">
                <input type="password" name="password_1" onblur="preencherCampo(value, 'password')" value="<?php if(isset($_POST['password'])) echo $_POST['password'];?>" placeholder="Senha">
            </div>
        </div>
    </div>
</div>

<div class="tab">
    <button class="tablinks"  onclick="openTab(0, 'Consulta-Notas')">Consultar Notas</button>
    <button class="tablinks" onclick="openTab(1, 'Enviar-xml')">Enviar xml</button>
</div>

<div id="Consulta-Notas" class="tabcontent">
    <div class="container">
        
        <form action="http://localhost/xmldestinadas/index.php" method="post">
            <input type="hidden" id="token" name="token" value="<?php if(isset($_POST['token'])) echo $_POST['token']; ?>"  placeholder="Token.." />
            <input type="hidden" name="login" value="<?php if(isset($_POST['login'])) echo $_POST['login'];?>" placeholder="E-mail">
            <input type="hidden" name="password" value="<?php if(isset($_POST['password'])) echo $_POST['password'];?>" placeholder="Senha">

            
                <div class="row">
                    <div class="col-10">
                        <label for="data-ini">Data inicio:</label>
                    </div>
                    <div class="col-30">
                        <input type="date" name="data-ini" id="date" value="<?php if(isset($_POST['data-ini'])) echo $_POST['data-ini']; ?>">
                    </div>
                </div>

                <div class="row">
                    <div class="col-10">
                        <label for="data-fim">Data final:</label>
                    </div>
                    <div class="col-30">
                        <input type="date" name="data-fim" id="date" value="<?php if(isset($_POST['data-fim'])) echo $_POST['data-fim']; ?>">   
                    </div>
                </div>

                <div class="row">
                    <div class="col-10">
                    <label for="mod">Modelo:</label>
                    </div>
                    <div class="col-90">
                    <?php 
                        isset($_POST['mod']) ? $md = $_POST['mod'] : $md = "";   
                    ?>
                        <select name="mod">
                            <option <?php if($md == "NFE")echo "selected";  ?> value="NFE" selected>NFE</option> 
                            <option <?php if($md == "NFCE")echo "selected";  ?> value="NFCE">NFCE</option>
                            <option <?php if($md == "CTE")echo "selected";  ?> value="CTE">CTE</option>
                            <option <?php if($md == "CCE")echo "selected";  ?> value="CCE">CCE</option>
                            <option <?php if($md == "CCECTE")echo "selected";  ?> value="CCECTE">CCECTE</option>
                            <option <?php if($md == "SAT")echo "selected";  ?> value="SAT">SAT</option>
                            <option <?php if($md == "CTEOS")echo "selected";  ?> value="CTEOS">CTEOS</option>
                        </select>
                    </div>
                </div>

                <div class="row">
                    <div class="col-10">
                    <label for="transaction">Tipo nota:</label>
                    </div>
                    <div class="col-90">

                    <?php 
                        isset($_POST['transaction']) ? $tp = $_POST['transaction'] : $tp = "";   
                    ?>

                        <select name="transaction"  >
                            <option <?php if($tp == "sent")echo "selected";  ?> value="sent" selected>Enviadas</option> 
                            <option <?php if($tp == "received")echo "selected";  ?> value="received">Recebidas</option>
                            <option <?php if($tp == "other")echo "selected";  ?> value="other">Outras</option>
                            <option <?php if($tp == "all")echo "selected";  ?> value="all">Totas</option>
                        </select>
                    </div>
                </div>

                <div class="row">
                    <div class="col-10">
                    <label for="filter">Filtro:</label>
                    </div>
                    <div class="col-90">

                    <?php 
                        isset($_POST['filter']) ? $fl = $_POST['filter'] : $fl = "";   
                    ?>

                        <select name="filter"  >
                            <option <?php if($fl == "downloaded")echo "selected";  ?> value="downloaded" selected>Notas baixadas</option> 
                            <option <?php if($fl == "not_downloaded")echo "selected";  ?> value="not_downloaded">Notas não baixadas</option>
                            <option <?php if($fl == "all")echo "selected";  ?> value="all">Todas</option>
                        </select>
                    </div>
                </div>

                <div class="row">
                    <input type="submit" value="Consultar">
                </div>


                    <div style="overflow-x:auto;">
                    <?php
            


                    if(!empty($_POST['login']) && !empty($_POST['token']) && !empty($_POST['login']) && !empty($_POST['data-ini']) && !empty($_POST['data-fim']) && !empty($_POST['mod'])) 
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
                        CURLOPT_URL => "https://app.notasegura.com.br/api/invoices/keys?token=".$token."&date_ini=".$data_ini."&date_end=".$data_fim."&mod=".$mod."&transaction=".$_POST['transaction']."&limit=30&last_id=&filter=".$fl,
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
                            if(isset($response->error))
                            {   
                                if($response->error == true)
                                {
                                    echo $response->message;
                                    exit;
                                }
                                
                            }
                            

                            $total  = $response->data->total;
                            $notas  = $response->data->invoices;
                            $lastid = $response->data->last_id; 
                            $count  = $response->data->count;
                            //

                            echo '<table id="myTable" class="display"> <thead><tr><th>Chaves das notas</th><th>Série</th> <th> Número nota</th><th>Cnpj emitente</th><th>Valor total</th></tr> </thead> <tbody>';
                            //PERCORRENDO AS PRIMEIRAS NOTAS BUSCADAS
                            foreach($notas as $n){
                                echo '<tr>';
                                echo '<td><a href="http://localhost/xmldestinadas/xml.php?key='.$n->key.'&auth='.$auth.'&token='.$token.'">'.$n->key.'</a> </td>';
                                echo '<td>'.$n->serie.'</td>';
                                echo '<td>'.$n->number.'</td>';
                                echo '<td>'.$n->cnpj_emitter.'</td>';
                                echo '<td>'.$n->value.'</td>';
                                echo '</tr>';
                            }

                            //VERIFICA SE EXISTE MAIS NOTAS, CASO EXISTE REALIZA A BUSCA
                            $total -= $count;
                            while ($total > 0) {

                            //BUSCAR RESTANTE DAS NOTAS
                            $curl = curl_init();
                            curl_setopt($curl, CURLOPT_SSL_VERIFYHOST, 0);
                            curl_setopt($curl, CURLOPT_SSL_VERIFYPEER, 0);
                            curl_setopt_array($curl, array(
                                CURLOPT_URL => "https://app.notasegura.com.br/api/invoices/keys?token=".$token."&date_ini=".$data_ini."&date_end=".$data_fim."&mod=".$mod."&transaction=".$_POST['transaction']."&limit=30&last_id=".$lastid."&filter=".$fl,
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
                                    echo '<tr>';
                                    echo '<td><a href="http://localhost/xmldestinadas/xml.php?key='.$s->key.'&auth='.$auth.'&token='.$token.'">'.$s->key.'</a> </td>';
                                    echo '<td>'.$n->serie.'</td>';
                                    echo '<td>'.$n->number.'</td>';
                                    echo '<td>'.$n->cnpj_emitter.'</td>';
                                    echo '<td>'.$n->value.'</td>';
                                    echo '</tr>';
                                }
                            }
                            $total -= $count;
                            
                            }
                            echo '</tbody></table>';
                        }
                    }   
                        
                        ?>
                        
                </div>
            
        </form>
    </div>  
   
</div>

<div id="Enviar-xml" class="tabcontent">
    
    <div class="container">
        <form action="http://localhost/xmldestinadas/index.php" method="post">
            <input type="hidden" id="token" name="token" value="<?php if(isset($_POST['token'])) echo $_POST['token']; ?>"  placeholder="Token.." />
            <input type="hidden" name="login" value="<?php if(isset($_POST['login'])) echo $_POST['login'];?>" placeholder="E-mail">
            <input type="hidden" name="password" value="<?php if(isset($_POST['password'])) echo $_POST['password'];?>" placeholder="Senha">
            <div class="row">
                <div class="col-25">
                    <label for="xml">Informar xml:</label>
                </div>
                <div class="col-75">
                    <textarea id="xml" name="xml" placeholder="Informar o xml..." style="height:200px"></textarea>
                </div>
            </div>

            <div class="row">
                <input type="submit" value="Enviar">
            </div>

        </form>
        <?php 


                    if(!empty($_POST['login']) && !empty($_POST['token']) && !empty($_POST['password']) && !empty($_POST['xml']) && isset($_POST['xml'])) 
                    {


                        $auth = base64_encode($_POST['login'].':'.$_POST['password']);

                        $curl = curl_init();
                        curl_setopt($curl, CURLOPT_SSL_VERIFYHOST, 0);
                        curl_setopt($curl, CURLOPT_SSL_VERIFYPEER, 0);


                        curl_setopt_array($curl, array(
                        CURLOPT_URL => "https://app.notasegura.com.br/api/invoices?token=".$_POST['token'],
                        CURLOPT_RETURNTRANSFER => true,
                        CURLOPT_ENCODING => "",
                        CURLOPT_MAXREDIRS => 10,
                        CURLOPT_TIMEOUT => 30,
                        CURLOPT_HTTP_VERSION => CURL_HTTP_VERSION_1_1,
                        CURLOPT_CUSTOMREQUEST => "POST",
                        CURLOPT_POSTFIELDS => "xml=".urlencode($_POST['xml']),
                        CURLOPT_HTTPHEADER => array(
                            "Accept: */*",
                            "Accept-Encoding: gzip, deflate",
                            "Authorization: Basic ".$auth,
                            "Cache-Control: no-cache",
                            "Connection: keep-alive",
                            "Host: app.notasegura.com.br",
                            "cache-control: no-cache"
                        ),
                        ));

                        $response = curl_exec($curl);
                        $err = curl_error($curl);
                        curl_close($curl);


                        if ($err) {
                            echo "cURL Error #:" . $err;
                        }else{
                            $xml  = new SimpleXMLElement($response);
                            echo "<script>alert('".substr($xml->message,0,-1)."'); </script>";
                        }
                        echo "<script>openTab(1, 'Enviar-xml')</script>";
                    }
             ?>
    </div>
</div>


</body>



<script>
    var tab,bbo,a;


    tab = document.getElementsByClassName("tablinks");
    for (a = 0; a < tab.length; a++) 
        if(tab[a].className.search(/ active/) != -1) bbo = true;


    
    if(bbo != true)
    {
        openTab(0,'Consulta-Notas')
    }

    function preencherCampo(valor,  campo) {

            var elements = document.querySelectorAll("input[name=" + campo + "]");
            for (i = 0; i < elements.length; i++) {
                elements[i].value= valor;
            }

    }

    $(document).ready( function () {
            $('#myTable').DataTable();
    } );
</script>

</html>

