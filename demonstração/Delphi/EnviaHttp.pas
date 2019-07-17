unit EnviaHttp;

interface

uses
  Winapi.Windows, Winapi.Messages, System.SysUtils, System.Variants, System.Classes, Vcl.Graphics,
  Vcl.Controls, Vcl.Forms, Vcl.Dialogs, Vcl.StdCtrls, Vcl.ExtCtrls, DateUtils, IdBaseComponent, IdComponent,
  IdTCPConnection, IdTCPClient, IdHTTP, IdIOHandler, IdIOHandlerSocket,
  IdIOHandlerStack, IdSSL, IdSSLOpenSSL, Vcl.ComCtrls;

type
  TForm4 = class(TForm)
    edtUser: TLabeledEdit;
    edtSenha: TLabeledEdit;
    edtToken: TLabeledEdit;
    pgc1: TPageControl;
    tsEnviarXml: TTabSheet;
    tsCadastroUser: TTabSheet;
    btnArquivo: TButton;
    mmoXML: TMemo;
    mmoRetorno: TMemo;
    btnEnviar: TButton;
    OpenDialog: TOpenDialog;
    lbl1: TLabel;
    lbl2: TLabel;
    edtCorporateName: TLabeledEdit;
    edtName: TLabeledEdit;
    edtCpfCnpj: TLabeledEdit;
    edtEmail: TLabeledEdit;
    edtSenhaUser: TLabeledEdit;
    btnCadastrar: TButton;
    mmoCadastro: TMemo;
    Retorno: TLabel;
    procedure FormCreate(Sender: TObject);
    procedure btnEnviarClick(Sender: TObject);
    procedure btnArquivoClick(Sender: TObject);
    procedure btnCadastrarClick(Sender: TObject);
  private
    { Private declarations }
      fHTTPClient : TIdHTTP;
      fIOHandlerSocketOpenSSL : TIdSSLIOHandlerSocketOpenSSL;
      fParamList : TStringList;
      property HTTPClient : TIdHTTP read fHTTPClient write fHTTPClient;
      property ParamList : TStringList read fParamList write fParamList;
  public
    { Public declarations }
  end;

var
  Form4: TForm4;

implementation

{$R *.dfm}

procedure TForm4.btnArquivoClick(Sender: TObject);
var
 _xml : TStringStream;
 _file : string;
begin
mmoXML.Clear;
_xml := TStringStream.Create(nil);
if OpenDialog.Execute then
begin
  _file := OpenDialog.FileName;
end;
 _xml.LoadFromFile(_file);
 mmoXML.Text := _xml.DataString;
 FreeAndNil(_xml);
end;

procedure TForm4.btnCadastrarClick(Sender: TObject);
var
 url: string;
begin
  mmoCadastro.Clear;
  ParamList.Clear;
  mmoCadastro.Text := 'Cadastrando Usuario..';
  Application.ProcessMessages;
  url := 'https://app.notasegura.com.br/api/users/?softwarehouse=' + edtToken.Text;
  HTTPClient.Request.Accept := 'application/xml';
  HTTPClient.Request.ContentType := 'application/x-www-form-urlencoded';
  HTTPClient.Request.BasicAuthentication := False;
  HTTPClient.Request.Username := EmptyStr;
  HTTPClient.Request.Password := EmptyStr;
  ParamList.Values['corporate_name'] := edtCorporateName.Text;
  ParamList.Values['name'] := edtName.Text;
  ParamList.Values['email'] := edtEmail.Text;
  ParamList.Values['password'] := edtSenhaUser.Text;
  if Length(edtCpfCnpj.Text) = 14 then
  begin
    ParamList.Values['cnpj'] := edtCpfCnpj.Text;
    mmoCadastro.Clear;
    mmoCadastro.Text :=   fHTTPClient.Post(url, ParamList);
  end
  else if  Length(edtCpfCnpj.Text) = 11 then
  begin
    ParamList.Values['cpf'] := edtCpfCnpj.Text;
    mmoCadastro.Clear;
    mmoCadastro.Text :=   fHTTPClient.Post(url, ParamList);
  end
  else
  begin
    ShowMessage('Cpf ou Cnpj invalido');
    mmoCadastro.Text := 'Verifique o Cpf/Cnpj e tente novamente.'
  end;
end;

procedure TForm4.btnEnviarClick(Sender: TObject);
var
 url : string;
begin
  mmoRetorno.Clear;
  ParamList.Clear;
  mmoRetorno.Text := 'Enviando nota..';
  Application.ProcessMessages;
  url := 'https://app.notasegura.com.br/api/invoices';
  HTTPClient.Request.Accept := 'application/xml';
  HTTPClient.Request.ContentType := 'application/x-www-form-urlencoded';
  HTTPClient.Request.BasicAuthentication := True;
  HTTPClient.Request.Username := edtUser.Text;
  HTTPClient.Request.Password := edtSenha.Text;
  ParamList.Values['token'] := edtToken.Text;
  ParamList.Values['xml'] := mmoXML.Text;
  mmoRetorno.Clear;
  mmoRetorno.Text :=   fHTTPClient.Post(url, ParamList);
end;

procedure TForm4.FormCreate(Sender: TObject);
begin
  fHTTPClient := TIdHTTP.Create(nil);
  fIOHandlerSocketOpenSSL := TIdSSLIOHandlerSocketOpenSSL.Create(nil);
  fParamList := TStringList.Create;
  fParamList.NameValueSeparator := '=';
  HTTPClient.ProtocolVersion := pv1_1;
  HTTPClient.Request.UserAgent := 'Mozilla/5.0 (Windows NT 6.1; WOW64; Trident/7.0; rv:11.0) like Gecko';
  fHTTPClient.IOHandler := fIOHandlerSocketOpenSSL;


end;


end.
