$(window).load(function () {

	var size = 1;
	var button = 1;
	var button_class = "gallery-header-center-right-links-current";
	var normal_size_class = "gallery-content-center-normal";
	var full_size_class = "gallery-content-center-full";
	var $container = $('#gallery-content-center');

	$container.isotope({itemSelector : 'img'});


	function check_button(){
		$('.gallery-header-center-right-links').removeClass(button_class);
		if(button==1){
			$("#filter-all").addClass(button_class);
			$("#gallery-header-center-left-title").html('all Galleries');
		}
		if(button==2){
			$("#filter-studio").addClass(button_class);
			$("#gallery-header-center-left-title").html('Femme Gallery');
		}
		if(button==3){
			$("#filter-landscape").addClass(button_class);
			$("#gallery-header-center-left-title").html('Homme Gallery');
		}	
	}








	//	
	//function check_size(){
	//	$("#gallery-content-center").removeClass(normal_size_class).removeClass(full_size_class);
	//	if(size==0){
	//		$("#gallery-content-center").addClass(normal_size_class); 
	//		$("#gallery-header-center-left-icon").html('<span class="iconb" data-icon="&#xe23a;"></span>');
	//		}
	//	if(size==1){
	//		$("#gallery-content-center").addClass(c); 
	//		$("#gallery-header-center-left-icon").html('<span class="iconb" data-icon="&#xe23b;"></span>');
	//		}
	//	$container.isotope({itemSelector : 'img'});
	//}



	$("#filter-all").click(function() { $container.isotope({ filter: '.all' }); button = 1; check_button(); });
	$("#filter-studio").click(function() {  $container.isotope({ filter: '.Femme' }); button = 2; check_button();  });
	$("#filter-landscape").click(function() {  $container.isotope({ filter: '.Homme' }); button = 3; check_button();  });
	//$("#gallery-header-center-left-icon").click(function() { if(size==0){size=1;}else if(size==1){size=0;} check_size(); });


	check_button();
	//check_size();
});



function checkWidth(init)
{
	/*If browser resized, check width again */
	if ($(window).width() > 980) {

		$('#gallery-content-center').addClass('gallery-content-center-normal');
		$('#gallery-content-center').removeClass('gallery-content-center-full');
	}
	else {
		if (!init) {
			
			$('#gallery-content-center').addClass('gallery-content-center-full');
			$('#gallery-content-center').removeClass('gallery-content-center-normal');
		}
	}
}

$(document).ready(function() {
	checkWidth(true);

	$(window).resize(function() {
		checkWidth(false);
	});
});

