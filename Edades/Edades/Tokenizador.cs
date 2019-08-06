/*
 * Creado por SharpDevelop.
 * Usuario: ggonzalez
 * Fecha: 14/10/2008
 * Hora: 08:39 p.m.
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;

namespace CorrectorPrueba
{
	/// <summary>
	/// Description of Class1.
	/// </summary>
	class Tokenizador{
		int otr,ren;
    	char car;
		public Tokenizador(String fuente){
			bool otr=true;
        	bool ren=true;
	        int edo=0,ent,edoa=0;
	        int otro=0,cp=0;
	        char tkn[255];
	    	if(!eof(fd)){
	    	    tkn[0]='\0';
	    	    if(otr)
	    	    	//read(fd,&car,1);
	    	    otr=0;
	    	    do{
	              if(car=='_')						ent=0;
	              else{if(car>='0'&&car<='9')		ent=1;
	              else{if(car=='.')					ent=2;
	              else{if(car=='"')					ent=3;
	              else{if(car>='A'&&car<='Z')       ent=0;
	              else{if(car>='a'&&car<='z')       ent=0;
	              else{if(car=='+'||car=='-')		ent=4;
	              else{if(car=='*'||car=='/')       ent=4;
	              else{if(car=='<')                 ent=5;
	              else{if(car=='>')                 ent=6;
	              else{if(car=='=')					ent=7;
	              else{if(car==','||car==';')       ent=8;
	              else{if(car=='('||car==')')       ent=8;
	              else{if(car=='{'||car=='}')       ent=8;
	              else{if(car==' '||car=='\t')      ent=9;
	              else{if(car=='\n')	       		ent=10;
	              else                              ent=11;}}}}}}}}}}}}}}}
	              edoa=edo;
	              edo=estado(edo,ent);
	              if(edo==-1)
	                  otro=1;
	              else{
	                  tkn[cp]=car;
	                  tkn[cp+1]='\0';
	                  cp++;
	                  read(fd,&car,1);
	              }
	        	}while(otro==0);
	        	if(reservada(tkn)){
	                if(!strcmp(tkn,"int"))       C=encola(C,tkn,"reservada",0,ren);
	                if(!strcmp(tkn,"float"))     C=encola(C,tkn,"reservada",1,ren);
	                if(!strcmp(tkn,"void"))      C=encola(C,tkn,"reservada",2,ren);
	                if(!strcmp(tkn,"if"))        C=encola(C,tkn,"reservada",3,ren);
	                if(!strcmp(tkn,"else"))      C=encola(C,tkn,"reservada",4,ren);
	                if(!strcmp(tkn,"while"))     C=encola(C,tkn,"reservada",5,ren);
	                if(!strcmp(tkn,"print"))     C=encola(C,tkn,"reservada",6,ren);
	                if(!strcmp(tkn,"println"))   C=encola(C,tkn,"reservada",7,ren);
	                if(!strcmp(tkn,"return"))    C=encola(C,tkn,"reservada",8,ren);
	                if(!strcmp(tkn,"and"))       C=encola(C,tkn,"reservada",9,ren);
	                if(!strcmp(tkn,"or"))        C=encola(C,tkn,"reservada",10,ren);
	                if(!strcmp(tkn,"not"))       C=encola(C,tkn,"reservada",11,ren);
	            }
	        	else{
	                if(edoa==0){
	                    //read(fd,&car,1);
	                    otr=1;
	                    if(ent!=9&&ent!=10)
	                        printf("\n Token invalido - renglon: %d",ren);
	                    if(ent==10)
	                        ren++;
	                    return 0;
	                }
	                if(edoa==3||edoa==5||edoa==6){
	                    //read(fd,&car,1);
	                    otr=1;
	                    printf("\n Token invalido - renglon: %d",ren);
	                    return 0;
	                }
	                if(edoa==1)                     C=encola(C,tkn,"identificador",12,ren);
	                if(edoa==2)                     C=encola(C,tkn,"int",13,ren);
	                if(edoa==4)                     C=encola(C,tkn,"float",13,ren);
	                if(edoa==7)                     C=encola(C,tkn,"cadena",14,ren);
	                if(edoa==8||edoa==9||edoa==10)  C=encola(C,tkn,"relacional",26,ren);
	                if(edoa==11)                    C=encola(C,tkn,"asignacion",15,ren);
	                if(edoa==12){
	                    if(!strcmp(tkn,","))    C=encola(C,tkn,"delimitador",16,ren);// ,
	                    if(!strcmp(tkn,";"))    C=encola(C,tkn,"delimitador",17,ren);// ;
	                    if(!strcmp(tkn,"+"))    C=encola(C,tkn,"suma"       ,18,ren);// +
	                    if(!strcmp(tkn,"-"))    C=encola(C,tkn,"suma"       ,19,ren);// -
	                    if(!strcmp(tkn,"*"))    C=encola(C,tkn,"multi"      ,20,ren);// *
	                    if(!strcmp(tkn,"/"))    C=encola(C,tkn,"multi"      ,21,ren);// /
	                    if(!strcmp(tkn,"("))    C=encola(C,tkn,"delimitador",22,ren);// (
	                    if(!strcmp(tkn,")"))    C=encola(C,tkn,"delimitador",23,ren);// )
	                    if(!strcmp(tkn,"{"))    C=encola(C,tkn,"delimitador",24,ren);// {
	                    if(!strcmp(tkn,"}"))    C=encola(C,tkn,"delimitador",25,ren);// }
	                }
	            }
	            return 1;
	        }
	        return 0;
	    }
	    int reservada(char tkn[255]){
	    	int i;
	    	char reservadas[12][15]={"or","and","void","int","float","return",
	                                 "if","else","while","print","println","not",};
	    	for(i=0;i<12;i++)
	    		if(!strcmp(reservadas[i],tkn))
	    		   return 1;
	    	return 0;
	    }
	    int estado(int edo,int ent){		
	        return matrizL[edo][ent];
	    }
	}
}
